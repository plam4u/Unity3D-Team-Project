using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = target.transform.position;
		transform.position = new Vector3(offset.x + p.x, offset.y + p.y, offset.z + p.z);

	}
}
