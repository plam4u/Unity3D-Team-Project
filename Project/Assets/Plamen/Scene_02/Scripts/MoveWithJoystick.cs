using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveWithJoystick : MonoBehaviour {

	public float speed;
	public Text text;

	void Update()
	{
		float leftStickX = Input.GetAxis("Horizontal");
		float leftStickY = Input.GetAxis("Vertical");
		float rightStickX = Input.GetAxis("HorizontalR");
		float rightStickY = Input.GetAxis("VerticalR");

		rigidbody.velocity = new Vector3(leftStickX * speed, 0.0f, leftStickY * speed);

		if (rightStickX != 0 || rightStickY != 0)
		{
			rigidbody.rotation = Quaternion.Euler(0.0f, Mathf.Atan2(rightStickY, rightStickX) * 180/Mathf.PI + 90, 0.0f);
			text.text = "Left\n\t" + leftStickX + "\n\t" + leftStickY + "\nRight\n\t" + rightStickX + "\n\t" + rightStickY + "\n\t" + Mathf.Atan2(rightStickY, rightStickX) * 180 / Mathf.PI;
		}
	}
}
