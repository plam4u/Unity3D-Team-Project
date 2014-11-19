using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Need Tobe attach to a Empty game object
public class InGameMenu : MonoBehaviour
{
    public GUISkin inGameSkin = null;

    float menuWidth = 212.0f;
    float menuHeght = 160.0f;
    float menuPosX;
    float menuPosY;
    float menuItemX = 48;
    float menuItemY = 48;
    float menuItemOffX;
    float menuItemOffY;


    public Texture2D menuItem;
    public Texture2D menuBg;   

    void Awake()
    {
        menuPosX = Screen.width - menuWidth;
        menuPosY = Screen.height - menuHeght;        
    }

    void OnGUI()
    {
        GUI.skin = inGameSkin;
        All();
    }

    private void All()
    {
        GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght), menuBg);
            GUI.Button(new Rect(4, 4, 48, 48), menuItem);
            GUI.Button(new Rect(56, 4, 48, 48), menuItem);
            GUI.Button(new Rect(108, 4, 48, 48), menuItem);
            GUI.Button(new Rect(160, 4, 48, 48), menuItem);

            GUI.Button(new Rect(4, 56, 48, 48), menuItem);
            GUI.Button(new Rect(56, 56, 48, 48), menuItem);
            GUI.Button(new Rect(108, 56, 48, 48), menuItem);
            GUI.Button(new Rect(160, 56, 48, 48), menuItem);

            GUI.Button(new Rect(4, 108, 48, 48), menuItem);
            GUI.Button(new Rect(56, 108, 48, 48), menuItem);
            GUI.Button(new Rect(108, 108, 48, 48), menuItem);
            GUI.Button(new Rect(160, 108, 48, 48), menuItem);
            
        GUI.EndGroup();
    }

    private void Half()
    {
        GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght));
            GUI.Button(new Rect(10, 10, 40, 40), menuItem);
            GUI.Button(new Rect(60, 10, 40, 40), menuItem);
            GUI.Button(new Rect(110, 10, 40, 40), menuItem);
            GUI.Button(new Rect(10, 60, 40, 40), menuItem);        
        GUI.EndGroup();
    }

    private void TestMenu()
    {

        GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght));

        
        
        GUI.EndGroup();
    }

}
