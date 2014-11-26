using UnityEngine;
using System.Collections;

public class CheckFire : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
