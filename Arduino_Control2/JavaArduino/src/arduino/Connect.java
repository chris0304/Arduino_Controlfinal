package examples;

import java.util.Scanner;

import arduino.*;

public class Connect {

	public static void main(String[] args) {
		
		Scanner ob = new Scanner(System.in);
		Arduino arduino = new Arduino("cu.usbmodem1411", 9600); //enter the port name here, and ensure that Arduino is connected, otherwise exception will be thrown.
		arduino.openConnection();
		
		char input = ob.nextLine().charAt(0);
		
	}

}

