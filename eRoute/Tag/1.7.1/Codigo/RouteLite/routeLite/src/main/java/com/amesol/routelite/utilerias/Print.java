package com.amesol.routelite.utilerias;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.nio.charset.Charset;


import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.serialport.SerialPort;
import android.util.Log;
import android.widget.Toast;

public class Print {
	private Context mContext;

	private byte textSize = 0x06;
	
	public Print(Context context) {
		mContext = context;
		printer = new SerialPort();
		if (!initPrint())
			Toast.makeText(context, "init print failed", Toast.LENGTH_LONG).show();
		else
			Toast.makeText(context, "init print success", Toast.LENGTH_LONG).show();
	}

	private final static String TAG = "Print";

	// 操作串口
	private SerialPort printer;
	private int printer_fd;
	private DeviceControl DevCtrl; // 设备上电

	private int flog = 0;

	public boolean initPrint() {

		try {
			printer.OpenSerial("/dev/eser1", 9600);

		} catch (SecurityException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
			return false;
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
			return false;
		}
		printer_fd = printer.getFd();
		try {
			DevCtrl = new DeviceControl("/proc/driver/printer");
			DevCtrl.PowerOnDevice();
			flog = 1;
		} catch (SecurityException e) {
			e.printStackTrace();
			return false;
		} catch (IOException e) {
			Log.d(TAG, "AAA");
			return false;
		}
		// cancleInversion();
		// setHRI((byte)2);
		// byte[] cmd2 = {0x1d,0x6b,0x4a,0x41,0x01,0x7b,0x43,0x00};
		// printer.WriteSerialByte(printer_fd, cmd2);
		return true;
	}

	public void cancleInversion() {
		byte[] cmd = { 0x1b, 0x7b, 0 };// 取消颠倒模式
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void setHRI(byte data) {
		byte[] cmd = { 0x1d, 0x48, data };// new byte[3];
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void setHight(byte data) {
		byte[] cmd = { 0x1d, 0x68, data };
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void setWide(byte data) {
		byte[] cmd = { 0x1d, 0x77, data };
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void printEAN8Barcode(String data) {
		cancleInversion();
		byte[] cmd = new byte[11];
		cmd[0] = 0x1d;// EAN8
		cmd[1] = 0x6b;
		cmd[2] = 68;
		cmd[3] = 7;
		// byte[] printcmd = {0x1b,0x64,0x06};//打印并进纸6行
		if (data.length() > 8 || data.length() < 7) {
			Toast.makeText(mContext, "ERROR:The length of EAN8 is error", Toast.LENGTH_LONG)
					.show();
			return;
		}
		if (data.length() == 8) {
			data = data.substring(0, 7);
		}
		byte[] cmd1 = data.getBytes();
		System.arraycopy(cmd1, 0, cmd, 4, cmd1.length);
		// System.arraycopy(printcmd, 0, cmd, cmd1.length + 4, printcmd.length);
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void printEAN13Barcode(String data) {
		cancleInversion();
		byte[] cmd = new byte[16];
		cmd[0] = 0x1d;// EAN13
		cmd[1] = 0x6b;
		cmd[2] = 67;
		cmd[3] = 13;
		// byte[] printcmd = {0x1b,0x4a,30};//打印并进纸6行
		if (data.length() > 13 || data.length() < 12) {
			Toast.makeText(mContext, "ERROR:The length of EAN13 is error", Toast.LENGTH_LONG)
					.show();
			return;
		}
		if (data.length() == 13) {
			data = data.substring(0, 12);
		}
		byte[] cmd1 = data.getBytes();
		System.arraycopy(cmd1, 0, cmd, 4, cmd1.length);
		// System.arraycopy(printcmd, 0, cmd, cmd1.length + 4, printcmd.length);
		printer.WriteSerialByte(printer_fd, cmd);
	}

	public void printCode39Barcode(String data) {
		cancleInversion();
		byte[] cmd = new byte[7 + data.length()];
		cmd[0] = 0x1d;// code39
		cmd[1] = 0x77;
		cmd[2] = 01;
		cmd[3] = 0x1d;// code39
		cmd[4] = 0x6b;
		cmd[5] = 69;
		cmd[6] = (byte) (data.length());
		// byte[] printcmd = {0x1b,0x64,0x06};//打印并进纸6行

		byte[] cmd1;
		try {
			cmd1 = data.getBytes("UTF-8");
			System.arraycopy(cmd1, 0, cmd, 7, cmd1.length);
			// System.arraycopy(printcmd, 0, cmd, cmd1.length + 4,
			// printcmd.length);
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/*
		 * for(int i = 0;i < cmd.length;i++) { Log.d(TAG,cmd[i] + ""); }
		 */
		Log.d(TAG, "ceshi : " + bystesToStr(cmd, 0, cmd.length));
		printer.WriteSerialByte(printer_fd, cmd);
	}

	/**
	 * 打印code128 
	 * @param data
	 */
	public void printCode128Barcode(String data) {
		cancleInversion();
		// setHight((byte)2);
		byte[] cmd1;
		try {
			cmd1 = data.getBytes("UTF-8");
			byte[] cmd = new byte[4 + cmd1.length];
			System.arraycopy(cmd1, 0, cmd, 4, cmd1.length);
			// System.arraycopy(printcmd, 0, cmd, cmd1.length + 4,
			// printcmd.length);
			cmd[0] = 0x1d;// code128
			cmd[1] = 0x6b;
			cmd[2] = 74;
			cmd[3] = (byte) (data.length());
			// byte[] printcmd = {0x1b,0x64,0x06};//打印并进纸6行
			Log.d(TAG, "ceshi : " + bystesToStr(cmd, 0, cmd.length));
			printer.WriteSerialByte(printer_fd, cmd);
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public void printBitMap() {
		cancleInversion();
//		Bitmap.printBitmap(printer, printer_fd);
	}
	
	public void setTextSize(byte textSize)
	{
		this.textSize = textSize;
	}

	public void printString(String data) {
		cancleInversion();
		byte[] cmdS1 = new byte[5];
		// cmdS1[0] = 0x1B;
		// cmdS1[1] = 0x4D;
		// cmdS1[2] = 0; //cmdS1设置字库，字形A（12*24）
		cmdS1[0] = 0x1c; // cmdS[0]、cmdS[1] 设置汉字模式
		cmdS1[1] = 0x26;
		/*
		 * cmdS1[2] = 0x1D; //Set the character size cmdS1[3] = 0x21; cmdS1[4] =
		 * 0x10; //width cmdS1[5] = 0x01; //high cmdS1[6] = 0x1D; //Set against
		 * the white model/ cmdS1[7] = 0x42; cmdS1[8] = 0x01;
		 */
		cmdS1[2] = 0x1b; // 打印打印并进纸
		cmdS1[3] = 0x64;
		cmdS1[4] = textSize;
		// cmdS1[2] = 0x02;
		byte[] data1 = null;
		byte[] data2;
		data2 = new byte[1];
		try {
			data1 = data.getBytes("GB2312");
//			data1 = data.getBytes("ISO-8859-1");
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		data2[0] = 0x0a;
		byte[] cmdS2 = new byte[data1.length + cmdS1.length];
		System.arraycopy(data1, 0, cmdS2, 0, data1.length);
		// System.arraycopy(data2,0,cmdS2,data1.length,data2.length);
		System.arraycopy(cmdS1, 0, cmdS2, data1.length, cmdS1.length);
		printer.WriteSerialByte(printer_fd, cmdS2);
	}

	public void closePrint() {
		printer.CloseSerial(printer_fd);
		try {
			DevCtrl.PowerOffDevice();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	public void powerOffPrint(){
		try {
			DevCtrl.PowerOffDevice();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	public void powerOnPrint(){
		try {
			DevCtrl.PowerOnDevice();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public String bystesToStr(byte[] s, int start, int len) {
		// CLogger.Write(s.Length + " start:" + start + " len:" + len);
		StringBuilder sb = new StringBuilder();
		for (int i = start; i < start + len; i++) {
			sb.append(String.format("%X ", s[i] & 0xff));
			sb.append(" ");
		}
		return sb.toString();
	}
}
