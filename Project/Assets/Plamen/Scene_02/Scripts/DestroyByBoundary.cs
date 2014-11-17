using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.transform.parent != null)
		{
			Destroy(other.transform.parent.gameObject);
		}
		else
		{
			Destroy(other.transform.gameObject);
		}
	}
}
