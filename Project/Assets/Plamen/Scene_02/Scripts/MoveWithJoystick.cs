using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveWithJoystick : MonoBehaviour {

	public float speed;
	public Text text;
	public GameObject bullet;

	private float nextFire;
	private float fireRate;

	void Start()
	{
		fireRate = 0.005f;
		nextFire = 0;
		text.text = "";
	}

	void Update()
	{
		rigidbody.angularVelocity = Vector3.zero;

		float leftStickX = Input.GetAxis("Horizontal");
		float leftStickY = Input.GetAxis("Vertical");
		float rightStickX = Input.GetAxis("HorizontalR");
		float rightStickY = Input.GetAxis("VerticalR");

		rigidbody.velocity = new Vector3(leftStickX * speed, 0.0f, leftStickY * speed);

		if (rightStickX != 0 || rightStickY != 0)
		{
			rigidbody.rotation = Quaternion.Euler(0.0f, Mathf.Atan2(rightStickY, rightStickX) * 180/Mathf.PI + 90, 0.0f);
			//text.text = "Left\n\t" + leftStickX + "\n\t" + leftStickY + "\nRight\n\t" + rightStickX + "\n\t" + rightStickY + "\n\t" + Mathf.Atan2(rightStickY, rightStickX) * 180 / Mathf.PI;

			if(nextFire < Time.time)
			{
				Vector3 rotation = transform.rotation.eulerAngles;
				rotation.y += Random.Range(-5f, 5f);

				Vector3 position = transform.position;
				position.x += Mathf.Sin(rotation.y / 180 * Mathf.PI) * 1;
				position.z += Mathf.Cos(rotation.y / 180 * Mathf.PI) * 1;
				//position.x -= Mathf.Cos(rotation.y) * 1f;
				//position.z -= Mathf.Sin(rotation.y) * 1f;

				Instantiate(bullet, position, Quaternion.Euler(rotation));

				nextFire = Time.time + fireRate;
			}
		}
	}
}
