using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public int speed;
	public bool variableSpeed;

	void Start()
	{
		rigidbody.velocity = transform.forward * (variableSpeed ? Random.value : 1) * speed;
	}
}
