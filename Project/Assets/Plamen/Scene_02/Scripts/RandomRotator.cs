using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * 5;
	}
}
