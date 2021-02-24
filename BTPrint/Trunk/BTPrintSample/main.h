#include <windows.h>
#include <windowsx.h>

BOOL	CALLBACK	DialogFunc(HWND hdwnd, UINT Msg, WPARAM wParam, LPARAM lParam);
void BTPrintThread(void);
int BTPrintThreadStart(void);
bool findBluetoothPort(TCHAR name[6]);

/* functions to get and set reg values */
BOOL RegGetValue(HKEY hRootKey, LPCTSTR lpSubKey, LPCTSTR lpValueName, LPDWORD lpType, LPBYTE lpData, LPDWORD lpcbDataLen); 
BOOL RegGetValueDWORD(HKEY hRootKey, LPCTSTR lpSubKey, LPCWSTR lpValueName, DWORD * lpData);
BOOL RegGetValueString(HKEY hRootKey, LPCTSTR szSubKey, LPCTSTR lpValueName,LPBYTE lpData, LPDWORD lpDataLen); 

