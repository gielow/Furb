//DANIEL GIELOW JUNIOR

package Questao6;

public class Strings {
	
	public static String leftPad(String str, int size) {
	      return leftPad(str, size, ' ');
	  }
	
	public static String leftPad(String str, int size, char padChar) {
	      if (str == null) {
	          return null;
	      }
	      int pads = size - str.length();
	      if (pads <= 0) {
	          return str; // returns original String when possible
	      }
	      return padding(pads, padChar).concat(str);
	}
	
	private static String padding(int repeat, char padChar) throws IndexOutOfBoundsException {
	      if (repeat < 0) {
	          throw new IndexOutOfBoundsException("Cannot pad a negative amount: " + repeat);
	      }
	      final char[] buf = new char[repeat];
	      for (int i = 0; i < buf.length; i++) {
	          buf[i] = padChar;
	      }
	      return new String(buf);
	}
	
	public static boolean isEmpty(String str) {
	      return str == null || str.length() == 0;
	}	
}
