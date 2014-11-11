using UnityEngine;
using System.Collections;

public class KeyboardControlled : MonoBehaviour {

    Vector2 velocity = new Vector2();
	float speed = 10F;
	float maxSpeed = 15F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		velocity.x += Input.GetAxis("Horizontal") * speed;
		velocity.y += Input.GetAxis("Vertical") * speed;
		velocity.x *= Time.deltaTime;
		velocity.y *= Time.deltaTime;

		float translateX = Mathf.Max(Mathf.Min(maxSpeed, velocity.x), -maxSpeed);
		float translateY = Mathf.Max(Mathf.Min(maxSpeed, velocity.y), -maxSpeed);

		Vector3 p = transform.position;
		transform.position = new Vector3(p.x + velocity.x, p.y + velocity.y, p.z);

		float diffX = Input.mousePosition.x - Screen.width/2;
		float diffY = Input.mousePosition.y - Screen.height/2;
		float angle = Mathf.Atan2(diffY,diffX);
		transform.eulerAngles = new Vector3(0, 0, angle * 180/Mathf.PI);
	}
}
