/*======================================================================

	UNLESS OTHER WISE AGREED TO BY HONEYWELL AND THE USER OF THIS CODE,
	THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
	THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.

	COPYRIGHT (C) 2009 HONEYWELL, Inc.

	THIS SOFTWARE IS PROTECTED BY COPYRIGHT LAWS OF THE UNITED STATES OF 
	AMERICA AND OF FOREIGN COUNTRIES. THIS SOFTWARE IS FURNISHED UNDER A 
	LICENSE AND/OR A NONDISCLOSURE AGREEMENT AND MAY BE USED IN ACCORDANCE 
	WITH THE TERMS OF THOSE	AGREEMENTS. UNAUTHORIZED REPRODUCTION, 
	DUPLICATION OR DISTRIBUTION OF THIS SOFTWARE, OR ANY PORTION OF IT 
	WILL BE PROSECUTED TO THE MAXIMUM EXTENT POSSIBLE UNDER THE LAW.

======================================================================*/
/*======================================================================
// BTPrintSample:	It send a file named sample.prn to a BT printer 
//
//					The file sample.prn need to be in the same folder
//					of BTPrintSample
======================================================================*/
#ifndef STRICT
#define STRICT
#endif

#include <windows.h>
#include <windowsx.h>
#include <commctrl.h>
#include <stdlib.h>
#include <winuser.h>
#include "resource.h"
#include "main.h"

#define DIM(x) (sizeof(x)/sizeof(x[0]))

/* global data */
HINSTANCE g_hInst;
HWND g_hwndMain;
TCHAR g_szFilename[MAX_PATH];
TCHAR g_szComPort[16];
TCHAR g_szTitle[MAX_PATH];
int g_CloseDelay=5000;
int g_AutoClose=1;
int g_PrintThreadActive=0;
int g_LineFeed=0;
int g_Retry=5;

BOOL g_FirstBTStatusSend=true;

/******************************************************************************  

  Application entry point

******************************************************************************/
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPWSTR lpCmdLine, int nShowCmd)
{
	int nLen;

	g_szComPort[0]=0;							// Empty initially to force autodetection

	wcscpy(g_szTitle,TEXT("Print Status"));		// set the default caption

	//GetModuleFileName(NULL, g_szFilename, MAX_PATH);
	//nLen = _tcslen(g_szFilename);	

	//for(int i=(nLen-1); i>=0; i--)				// Search backward for the first slash.
	//{
	//	if(_T('\\') == g_szFilename[i])
	//	{
	//		g_szFilename[i] = _T('\0');			// Cut the filename
	//		break;
	//	}
	//}

	// Add the file name to the path of the executable
	wcscat(g_szFilename, _T("\\Impresion.txt")); 		

	InitCommonControls();

	g_hInst=hInstance;
	DialogBox(hInstance, MAKEINTRESOURCE(IDD_MAIN), 0, (DLGPROC)DialogFunc);

	return 0;
}

/******************************************************************************  

  Callback function for main Dialog (IDD_MAIN)

******************************************************************************/
BOOL CALLBACK DialogFunc(HWND hwnd, UINT Msg, WPARAM wParam, LPARAM lParam)
{
	switch(Msg)
	{
		
		case WM_INITDIALOG:

			g_hwndMain=hwnd;
			
			/* set the title */
			SetWindowText(hwnd, g_szTitle);

			//SetWindowPos(hwnd, HWND_TOPMOST,0,0,0,0,SWP_NOMOVE| SWP_NOSIZE);
			SetWindowPos(hwnd, HWND_TOPMOST,0,0,260,320,SWP_NOOWNERZORDER);
			

			/* print the file */
			if (g_szFilename[0]!=0)
			{
				g_FirstBTStatusSend=true;
				SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("Printing..."));
				BTPrintThreadStart();
			}
			else
			{
				SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("Invalid filename"));
			}
			
			return TRUE;
	
		case WM_KEYDOWN:
			switch(wParam)
			{
				case 27:			
					SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("Aborting"));
					if(!g_PrintThreadActive) 
						SendMessage(g_hwndMain, WM_QUIT,0,0);
					break;
			}
			return TRUE;

	
		case WM_COMMAND:

			switch(LOWORD(wParam))
			{

				case IDCANCEL:
					SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("Aborting"));
					if(!g_PrintThreadActive) 
						SendMessage(g_hwndMain, WM_QUIT,0,0);
					break;

				default:
					return FALSE;
			}
			return TRUE;

		case WM_QUIT:
			PostQuitMessage (0);
			return TRUE;

		case WM_DESTROY:
			EndDialog(hwnd, 0);
			return TRUE;
	}
	
	return FALSE;
}

/******************************************************************************				

int BTPrintThreadStart(void)

******************************************************************************/
int BTPrintThreadStart(void)
{

	HANDLE hBTPrintThread = NULL;
	
	DWORD dwThreadID = 0;
	hBTPrintThread  = CreateThread( NULL,
		0, 
		(LPTHREAD_START_ROUTINE) BTPrintThread,
		0,
		0,
		&dwThreadID);

	if (hBTPrintThread)
	{
		CloseHandle (hBTPrintThread);
	}
	else
	{
		return 1;
	}

	return 0;
}


/******************************************************************************				

void BTPrintThread(void)

******************************************************************************/
void BTPrintThread(void)
{
	TCHAR szout[8096];
	DCB port;
	HANDLE   hCom,hFile;
	unsigned long bytesWritten;
	int counter;
	TCHAR szValue[500];
	DWORD len = sizeof(szValue);

	g_PrintThreadActive=1;

	if (g_szComPort[0]==0)    // If no port given
	{
		if (!findBluetoothPort(g_szComPort))   //Dynamically try and find the COM port
		{ 
			//SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("No Bluetooth COM Port found"));			
			//goto ExitThread;

			PlaySound (TEXT("BUZZ"), g_hInst, SND_RESOURCE | SND_ASYNC);			
			Sleep(500);
			swprintf(szout, TEXT("No Bluetooth COM Port found"));		
			SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
			Sleep(3000);
			if (g_AutoClose)
				SendMessage(g_hwndMain, WM_QUIT,0,0);
			goto ExitThread;
		}
	}

	hFile = CreateFile(g_szFilename,GENERIC_READ,0,0,OPEN_EXISTING,0,0);	
	if (hFile==INVALID_HANDLE_VALUE)
	{
		//SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), TEXT("File not found"));		
		//goto ExitThread;

		PlaySound (TEXT("BUZZ"), g_hInst, SND_RESOURCE | SND_ASYNC);			
		Sleep(500);
		swprintf(szout, TEXT("File not found"));		
		SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
		Sleep(3000);
		if (g_AutoClose)
			SendMessage(g_hwndMain, WM_QUIT,0,0);
		goto ExitThread;
	}

	//ReadFile(hFile,szout,4048,&bytesWritten,NULL);
	ReadFile(hFile,szout,12144,&bytesWritten,NULL);

	//Try at least 3 times to get a valid handle
	for(counter = 0; counter < 2; ++counter)
	{
		hCom = CreateFile(g_szComPort,GENERIC_READ|GENERIC_WRITE,0,0,OPEN_EXISTING,0,0);
		if(hCom && hCom != INVALID_HANDLE_VALUE) 
		{
			counter = 3;
		}
	}

	if ( hCom == INVALID_HANDLE_VALUE )
	{
		//DWORD dwError = GetLastError();
		//swprintf(szout, TEXT("BlueTooth Connection failed! "));
		//SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);		
		//goto ExitThread;

		PlaySound (TEXT("BUZZ"), g_hInst, SND_RESOURCE | SND_ASYNC);			
		Sleep(500);
		swprintf(szout, TEXT("BlueTooth Connection failed!"));		
		SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
		Sleep(3000);
		if (g_AutoClose)
			SendMessage(g_hwndMain, WM_QUIT,0,0);
		goto ExitThread;
	}

	// // Initialize the DCBlength member. 
	port.DCBlength = sizeof (DCB);
	GetCommState (hCom, &port);

	//Setup the COM port
	port.BaudRate = 57600;
	port.Parity = NOPARITY;
	port.StopBits = 1;
	port.ByteSize = 8;

	// Connect to the Bluetooth printer
	if (!SetCommState (hCom, &port))
	{
		PlaySound (TEXT("BUZZ"), g_hInst, SND_RESOURCE | SND_ASYNC);			
		Sleep(500);
		swprintf(szout, TEXT("BlueTooth Connection failed!"));
		SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
		if (g_AutoClose)
			SendMessage(g_hwndMain, WM_QUIT,0,0);
		goto ExitThread;
	}

	// Write file to Bluetooth COM port
	//if(WriteFile(hCom,szout,4048,&bytesWritten,NULL)==0)
	if(WriteFile(hCom,szout,12144,&bytesWritten,NULL)==0)
	{
		//swprintf(szout, TEXT("Error Printing"));
		//SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
		//goto ExitThread;

		PlaySound (TEXT("BUZZ"), g_hInst, SND_RESOURCE | SND_ASYNC);			
		Sleep(500);
		swprintf(szout, TEXT("Error Printing"));		
		SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);
		Sleep(3000);
		if (g_AutoClose)
			SendMessage(g_hwndMain, WM_QUIT,0,0);
		goto ExitThread;
	}

	Sleep(g_CloseDelay);
	swprintf(szout, TEXT("Printing complete"));
	SetWindowText(GetDlgItem(g_hwndMain, IDC_STATUS), szout);

	PlaySound (TEXT("BEEP"), g_hInst, SND_RESOURCE | SND_ASYNC);			
	Sleep(100);
	PlaySound (TEXT("BEEP"), g_hInst, SND_RESOURCE | SND_ASYNC);			
	Sleep(100);
	PlaySound (TEXT("BEEP"), g_hInst, SND_RESOURCE | SND_ASYNC);			
	Sleep(100);

	if (g_AutoClose)
		SendMessage(g_hwndMain, WM_QUIT,0,0);

	ExitThread:
		g_PrintThreadActive=0;

	ExitThread(1);
}

#define MSS_PORTS_BASE _T("\\Software\\Microsoft\\Bluetooth\\Serial\\Ports")
#define dim(x) (sizeof(x) / sizeof(x[0])) 

bool findBluetoothPort(TCHAR name[6])
{
	HKEY	hKey,hSubKey, hRoot;
	TCHAR	szActiveKey[20], szPort[20] = _T(""), szPortString[20];
	DWORD	len, dwIndex=0, dwType, dwRole;	
	bool bFound=false;

  INT i = 0, rc;
  DWORD dwNSize;
  DWORD dwCSize;
  TCHAR szClass[256];
  TCHAR szName[MAX_PATH];
  FILETIME ft;

  hRoot = HKEY_LOCAL_MACHINE;


  if (RegOpenKeyEx (hRoot, MSS_PORTS_BASE, 0, 0, &hKey) != ERROR_SUCCESS)
  {	rc = GetLastError();
  return 0;
  }

  dwNSize = dim(szName);
  dwCSize = dim(szClass);
  rc = RegEnumKeyEx (hKey, i, szName, &dwNSize, NULL, szClass, &dwCSize, &ft);
  while (rc == ERROR_SUCCESS)
	{
		// how many children
		TCHAR szCurrentKey[MAX_PATH];
		wcscpy(szCurrentKey, MSS_PORTS_BASE);
		wcscat(szCurrentKey, TEXT("\\"));
		wcscat(szCurrentKey, szName);
		wcscat(szCurrentKey, TEXT("\\"));

		len = sizeof(szPort);
		if(RegGetValue(hRoot, szCurrentKey, _T("Port"), NULL, (LPBYTE)szPort, &len))
		{
			wsprintf(szPortString, _T("%s:"), szPort);
			bFound = true;
			break;
		}
		
    dwNSize = dim(szName);
    rc = RegEnumKeyEx(hKey, ++i, szName, &dwNSize, NULL, NULL, 0, &ft);
  }

  if(bFound)
	  _tcscpy(name, szPortString);	

  return bFound;
}


// read a int value from the registry
BOOL RegGetValueDWORD(HKEY hRootKey, LPCTSTR lpSubKey, LPCTSTR lpValueName, DWORD * lpData) 
{
   DWORD dwDataSize=sizeof(DWORD);
   return RegGetValue(hRootKey,lpSubKey, lpValueName, NULL, (LPBYTE) lpData, &dwDataSize);
}


// read a string value from the registry
BOOL RegGetValueString(HKEY hRootKey, LPCTSTR lpSubKey, LPCTSTR lpValueName, LPBYTE lpData, LPDWORD lpDataLen) 
{
   return RegGetValue(hRootKey,lpSubKey, lpValueName, NULL, lpData, lpDataLen);
}


// read a value from the registry
BOOL RegGetValue(HKEY hRootKey, LPCTSTR lpSubKey, LPCTSTR lpValueName, LPDWORD lpType, LPBYTE lpData, LPDWORD lpcbDataLen)	
{
   LRESULT lResult = -1;
   HKEY hKey = NULL;
   lResult =RegOpenKeyEx(hRootKey, lpSubKey, 0, 0, &hKey);
   if (lResult  == ERROR_SUCCESS) 
   {
      lResult = RegQueryValueEx(hKey, lpValueName, NULL, lpType, lpData, lpcbDataLen);
      RegCloseKey(hKey);
   }
   return (lResult == ERROR_SUCCESS);
}

