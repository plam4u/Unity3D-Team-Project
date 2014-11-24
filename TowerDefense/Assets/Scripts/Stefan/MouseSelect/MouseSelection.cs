using UnityEngine;
using System.Collections;

public class MouseSelection : MonoBehaviour
{

    private bool selected = false;

    private GameObject prevGameObject;

    private GameObject currentGameObject;

    private LayerMask layerMask = 1 << 8;

    private bool buildMode = true;
    
    void Update()
    {

        if(buildMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, layerMask))
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

    }
}
