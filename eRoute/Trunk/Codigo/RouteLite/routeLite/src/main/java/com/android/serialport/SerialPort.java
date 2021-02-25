/*
 * Copyright 2009 Cedric Priscal
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 */

package com.android.serialport;

import java.io.IOException;
import java.io.UnsupportedEncodingException;

import android.R.integer;
import android.app.Activity;
import android.util.Log;

public class SerialPort {

	private static final String TAG = "SerialPortNative";

	/*
	 * Do not remove or rename the field mFd: it is used by native method
	 * close();
	 */
	private int fdx = -1;
	private int writelen;
	private String str;

	/*
	 * public SerialPort(String device, int baudrate) throws SecurityException,
	 * IOException {
	 * 
	 * fdx = open(device, baudrate); if (fdx < 0) { Log.e(TAG,
	 * "native open returns null"); throw new IOException(); } }
	 */
	public SerialPort() {

	}

	public void OpenSerial(String device, int baudrate)
			throws SecurityException, IOException {
		fdx = open(device, baudrate);
		if (fdx < 0) {
			Log.e(TAG, "native open returns null");
			throw new IOException();
		}
	}

	public void OpenSerialWithStopbit(String device, int baudrate, int stopbit)
			throws SecurityException, IOException {
		fdx = openport(device, baudrate, stopbit);
		if (fdx < 0) {
			Log.e(TAG, "native open returns null");
			throw new IOException();
		}
	}

	public int getFd() {
		return fdx;
	}

	public int WriteSerialString(int fd, String str, int len) {
		writelen = writestring(fd, str, len);
		return writelen;
	}

	public int WriteSerialByte(int fd, byte[] str) {
		writelen = writeport(fd, str);
		System.out.println("WriteSerial");
		return writelen;
	}

	public String ReadSerialString(int fd, int len)
			throws UnsupportedEncodingException {
		byte[] tmp;
		tmp = readport(fd, len);
		if (tmp == null) {
			return null;
		}
		if (isUTF8(tmp)) {
			str = new String(tmp, "utf8");
			Log.d(TAG, "is a utf8 string");
		} else {
			str = new String(tmp, "gbk");
			Log.d(TAG, "is a gbk string");
		}
		return str;
	}

	public byte[] ReadSerial(int fd, int len)
			throws UnsupportedEncodingException {
		byte[] tmp;
		tmp = readport(fd, len);
		if (tmp == null) {
			return null;
		}
		/*
		 * for(byte x : tmp) { Log.w("xxxx", String.format("0x%x", x)); }
		 */

		return tmp;
	}

	public void CloseSerial(int fd) {

		closeport(fd);
	}

	private boolean isUTF8(byte[] sx) {
		Log.d(TAG, "begian to set codeset");
		for (int i = 0; i < sx.length;) {
			if (sx[i] < 0) {
				if ((sx[i] >>> 5) == 0x7FFFFFE) {
					if (((i + 1) < sx.length)
							&& ((sx[i + 1] >>> 6) == 0x3FFFFFE)) {
						i = i + 2;
					} else {
						return false;
					}
				} else if ((sx[i] >>> 4) == 0xFFFFFFE) {
					if (((i + 2) < sx.length)
							&& ((sx[i + 1] >>> 6) == 0x3FFFFFE)
							&& ((sx[i + 2] >>> 6) == 0x3FFFFFE)) {
						i = i + 3;
					} else {
						return false;
					}
				} else {
					return false;
				}
			} else {
				i++;
			}
		}
		return true;
	}

	// JNI
	public native static int open(String dev, int baudrate);

	private native int openport(String port, int brd, int checkbit);

	private native void closeport(int fd);

	private native byte[] readport(int fd, int count);

	private native int writeport(int fd, byte[] buf);// byte

	public native static int writestring(int fd, String wb, int len);

	static {
		System.loadLibrary("serial_port");
	}

}
