using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public float chaseDistance;
	public float fireDistance;
	public float closeupDistance;

	void Start()
	{
		chaseDistance = 12;
		fireDistance = 8;
		closeupDistance = 3;
	}

	void Update()
	{

	}
}
