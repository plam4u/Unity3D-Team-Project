using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestJoystick : MonoBehaviour {

	public Text textField;
	// Use this for initialization
	void Start () {
		//for(int i = 0; i < Input.GetJoystickNames().Length; i++)
		//{
		//	Debug.Log(Input.GetJoystickNames()[i]);
		//}
	}
	
	// Update is called once per frame
    void Update()
    {
		float leftStickX = Input.GetAxis("Horizontal");
		float leftStickY = Input.GetAxis("Vertical");
		float rightStickX = Input.GetAxis("HorizontalR");
		float RightStickY = Input.GetAxis("VerticalR");

		string debugString = "left:\n\t" + leftStickX + "\n\t" + leftStickY + "\nright:\n\t" + rightStickX + "\n\t" + RightStickY;
		textField.text = debugString;

		//bool fire1 = Input.GetButton("Fire1");
		//Debug.Log("fire1: " + fire1);
	}
}
