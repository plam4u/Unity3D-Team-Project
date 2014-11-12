using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Vector3 r = transform.rotation.eulerAngles;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0, 0.5F, 0);
            cube.transform.eulerAngles = new Vector3(r.x, r.y, r.z);
            cube.AddComponent<MoveForward>();
            cube.renderer.material = null;
        }
	}
}
