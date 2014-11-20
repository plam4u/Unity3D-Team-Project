using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GUISkin menuSkin = null;

    public Texture2D menuItem;
    public Texture2D menuBg;

    float menuWidth = 400.0f;
    float menuHeght = 600.0f;
    float menuPosX;
    float menuPosY;



    public Color mainColor;

    void Awake()
    {
        menuPosX = (Screen.width / 2) - (menuWidth / 2);
        menuPosY = (Screen.height / 2) - (menuHeght / 2);

    }


    void OnGUI()
    {

        GUI.skin = menuSkin;
        GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght), menuBg);
        GUI.Box(new Rect(0, 30, menuWidth, menuHeght), "TOWER DEFENCE");
        GUI.BeginGroup(new Rect(100, 200, 200, 500));

        if(GUI.Button(new Rect(0, 0, 200, 50), "Start Game"))
        {
            //Debug.Log("Application Load Level");
            Application.LoadLevel("PlayScene");
        }

        if(GUI.Button(new Rect(0, 60, 200, 50), "Options"))
        {
            Debug.Log("Application Load Option");
        }

        if (GUI.Button(new Rect(0, 120, 200, 50), "Exit Game"))
        {
            Debug.Log("Application Quit");
        }
        
        GUI.EndGroup();
        GUI.EndGroup();

    }

}
