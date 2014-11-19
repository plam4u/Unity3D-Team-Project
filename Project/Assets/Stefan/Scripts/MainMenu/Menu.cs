using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public bool isQuit;
    public Color mainColor;

    void Start()
    {
        mainColor = renderer.material.color;
    }

    void OnMouseOver()
    {
        renderer.material.color = Color.gray;

    }

    void OnMouseExit()
    {
        renderer.material.color = mainColor;
    }


}
