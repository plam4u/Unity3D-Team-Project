using UnityEngine;
using System.Collections;

public class KeyboardControlled : MonoBehaviour {

    Vector2 velocity = new Vector2();
	float speed = 10F;
	//float maxSpeed = .35F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		float diffX = Input.mousePosition.x - Screen.width / 2;
		float diffY = Input.mousePosition.y - Screen.height / 2;
		float angle = Mathf.Atan2(diffY, diffX);
		transform.eulerAngles = new Vector3(0, 0, angle * 180 / Mathf.PI);

        float currentSpeed = speed * Time.deltaTime;
        velocity.x += Input.GetAxis("Horizontal") * (currentSpeed);
        velocity.y += Input.GetAxis("Vertical") * (currentSpeed);

        velocity.x = Mathf.Max(Mathf.Min(currentSpeed, velocity.x), -currentSpeed);
        velocity.y = Mathf.Max(Mathf.Min(currentSpeed, velocity.y), -currentSpeed);

        if (Input.GetAxis("Horizontal") == 0) velocity.x *= .7F;
        if (Input.GetAxis("Vertical") == 0) velocity.y *= .7F;

		Vector3 p = transform.position;
		transform.position = new Vector3(p.x + velocity.x, p.y + velocity.y, p.z);
	}
}
