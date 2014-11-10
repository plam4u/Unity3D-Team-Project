using UnityEngine;
using System.Collections;

public class KeyboardControlled : MonoBehaviour {

    Vector2 velocity = new Vector2();
	float speed = 0.05F;
	float maxSpeed = 0.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left"))
		{
			velocity.x -= speed * Time.deltaTime;
		}
		else if (Input.GetKey("right"))
		{
			velocity.x += speed * Time.deltaTime;
		}
		else
		{
			velocity.x *= 0.9F;
		}

		if (Input.GetKey("up") == true)
		{
			velocity.y += speed * Time.deltaTime;
		}
		else if (Input.GetKey("down") == true)
		{
			velocity.y -= speed * Time.deltaTime;
		}
		else
		{
			velocity.y *= 0.9F;
		}

		velocity.x = Mathf.Min(Mathf.Max(-maxSpeed, velocity.x), maxSpeed);
		velocity.y = Mathf.Min(Mathf.Max(-maxSpeed, velocity.y), maxSpeed);
		
		Vector3 p = transform.position;
		transform.position = new Vector3((float) p.x + velocity.x, (float) p.y + velocity.y, -0.62F);
	}
}
