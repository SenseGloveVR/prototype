using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Unity_Arduino_Control : MonoBehaviour {
	
	public bool freedom = true;
	public SerialPort serial = new SerialPort("/dev/tty.usbmodem1411", 9600);

	
	// Use this for initialization
	void Start () {
		serial.Open ();
		serial.ReadTimeout = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (serial.IsOpen) {
			
			if (Input.GetKeyUp (KeyCode.Space)) {
				freedom = true;
				serial.Write ("f");
				Debug.Log ("free");
			}
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				freedom = false;
				serial.Write ("s");
				Debug.Log ("stuck");
			}
			
		}	else if(!serial.IsOpen) {
			Debug.Log("serial isnt open");
		} 
	}
}


