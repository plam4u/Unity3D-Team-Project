using UnityEngine;
using System.Collections;

public class LightFlick : MonoBehaviour
{

    public Light flash;

    void Awake()
    {
        flash.enabled = false;
    }

    void Update()
    {
        float randNumber = Random.value;

        if (randNumber <= .7)
        {
            flash.enabled = true;
        }
        else
        {
            flash.enabled = false;
        }
    }
}
