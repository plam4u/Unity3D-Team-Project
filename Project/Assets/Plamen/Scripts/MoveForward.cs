using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("move forward");
        //transform.Translate(new Vector3(.1F, .1F, 0));
        transform.Translate(Vector3.forward * Time.deltaTime);
	}
}
