package com.amesol.routelite.utilerias;

import java.util.Arrays;

public class Token {

	public static final String llaveCodifica = "1593780642";
	
	private static char[] sortedAlphabet(String wheel){
		char[] alphabet = wheel.toCharArray();
		Arrays.sort(alphabet);
		return alphabet;
	}
	
	public static String conceal(String value, String wheel){
		char[] alphabet = sortedAlphabet(wheel);
		String result = "";
		for(int i = 0; i < value.length(); i++){
			int letterPosition = Arrays.binarySearch(alphabet, value.charAt(i));
			char encodedLetter = wheel.charAt((letterPosition + i) % wheel.length());
			result += encodedLetter;
		}
		return result;
	}
	
	public static String reveal(String input, String wheel){
		char[] alphabet = sortedAlphabet(wheel);
        String result = "";
        int alphabetIndex;
        for (int i = 0; i < input.length(); i++){
        	int currentCharPos = wheel.indexOf(input.charAt(i));
        	alphabetIndex = (currentCharPos + i) % wheel.length();
        	if(alphabetIndex < 0)
        		alphabetIndex += wheel.length();
        	result += alphabet[alphabetIndex];
        }
        return result;
	}
}
