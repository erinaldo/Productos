package com.amesol.pruebaandroid.enu;

public enum Entorno {
	trabajo("TRABAJO");
	
	
	private String text;

	Entorno(String text) {
		this.text = text;
	}

	public String toString() {
		return this.text;
	}

	public static Entorno fromString(String text) {
		if (text != null) {
			for (Entorno b : Entorno.values()) {
				if (text.equalsIgnoreCase(b.text)) {
					return b;
				}
			}
		}
		return null;
	}

}
