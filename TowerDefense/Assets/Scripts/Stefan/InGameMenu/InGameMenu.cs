using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Need Tobe attach to a Empty game object
//Need To be added to every scene 
//I make prefab, and must be added to every scene
public class InGameMenu : MonoBehaviour
{
    public GUISkin inGameSkin = null;
    public GUISkin statSkin = null;

    float menuWidth = 212.0f;
    float menuHeght = 160.0f;
    float menuPosX;
    float menuPosY;
    float menuItemX = 48;
    float menuItemY = 48;
    float menuItemOffX;
    float menuItemOffY;


    public Texture2D menuItem;
    public Texture2D menuItem1;
    public Texture2D menuItem2;
    public Texture2D menuItem3;
    public Texture2D menuItem4;
    public Texture2D menuItem5;
    public Texture2D menuItem6;
    public Texture2D menuItem7;
    public Texture2D menuItem8;
    public Texture2D menuItem9;
    public Texture2D menuItem10;
    public Texture2D menuItem11;
    public Texture2D menuBg;
    public Texture2D statsBar;

    public GameObject BuildObj;


    //Private var's
    private LayerMask layerMask = 1 << 8;

    private bool buildMode = false;

    private GameObject lastHitObj;

    private GameObject[] buildPlaces;

    private int score = 0;
    private int money = 1500;


    void Awake()
    {
        menuPosX = Screen.width - menuWidth;
        menuPosY = Screen.height - menuHeght;
        buildPlaces = GameObject.FindGameObjectsWithTag("BuildMask");
        ToggleMask(false);
    }


    void Update()
    {
        if (buildMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50, layerMask))
            {
                Debug.Log(hit.collider.tag);
                BuildObj.transform.position = hit.collider.transform.position;
            }

            if (Input.GetMouseButton(0))
            {
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<MeshCollider>().enabled = false;
                buildMode = false;
                ToggleMask(false);
            }
        }
    }


    //Render the ingame menu with GUI style
    void OnGUI()
    {
        GUI.skin = inGameSkin;
        InGame();
        Stats();
    }

    //This is the ingame Menu
    private void InGame()
    {

        GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght), menuBg);

        if (GUI.Button(new Rect(4, 4, 48, 48), menuItem))
        {
            //Debug.Log("Button 1");

            if (!buildMode)
            {
                ToggleMask(true);
                buildMode = true;
                BuildObj = Instantiate(BuildObj) as GameObject;
                BuildObj.tag = "Player";
                //TO DO: Activate Object - from state IDLE
            }
        }

        if (GUI.Button(new Rect(56, 4, 48, 48), menuItem1))
        {
            Debug.Log("Button 2");
            Debug.Log(buildPlaces.Length);

        }

        if (GUI.Button(new Rect(108, 4, 48, 48), menuItem2))
        {
            Debug.Log("Button 3");
        }

        if (GUI.Button(new Rect(160, 4, 48, 48), menuItem3))
        {
            Debug.Log("Button 4");
        }

        if (GUI.Button(new Rect(4, 56, 48, 48), menuItem4))
        {
            Debug.Log("Button 5");
        }

        if (GUI.Button(new Rect(56, 56, 48, 48), menuItem5))
        {
            Debug.Log("Button 6");
        }

        if (GUI.Button(new Rect(108, 56, 48, 48), menuItem6))
        {
            Debug.Log("Button 7");
        }

        if (GUI.Button(new Rect(160, 56, 48, 48), menuItem7))
        {
            Debug.Log("Button 8");
        }

        if (GUI.Button(new Rect(4, 108, 48, 48), menuItem8))
        {
            Debug.Log("Button 9");
        }

        if (GUI.Button(new Rect(56, 108, 48, 48), menuItem9))
        {
            Debug.Log("Button 10");
        }

        if (GUI.Button(new Rect(108, 108, 48, 48), menuItem10))
        {
            Debug.Log("Button 11");
        }

        if (GUI.Button(new Rect(160, 108, 48, 48), menuItem11))
        {
            Debug.Log("Button 12");
        }

        GUI.EndGroup();
    }

    private void ToggleMask(bool toggle)
    {
        foreach (GameObject place in buildPlaces)
        {
            place.GetComponent<MeshRenderer>().enabled = toggle;
        }
    }

    private void Stats()
    {
        
        GUI.BeginGroup(new Rect(0, 0, 300, 48), statsBar);
        GUI.Box(new Rect(40, 10, 100, 40), money.ToString());
        GUI.Box(new Rect(184, 10, 100, 40), score.ToString());
        GUI.EndGroup();
    }


    //For test and reference purpose
    //private void All()
    //{
    //    GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght), menuBg);

    //    GUI.Button(new Rect(4, 4, 48, 48), menuItem);
    //    GUI.Button(new Rect(56, 4, 48, 48), menuItem);
    //    GUI.Button(new Rect(108, 4, 48, 48), menuItem);
    //    GUI.Button(new Rect(160, 4, 48, 48), menuItem);

    //    GUI.Button(new Rect(4, 56, 48, 48), menuItem);
    //    GUI.Button(new Rect(56, 56, 48, 48), menuItem);
    //    GUI.Button(new Rect(108, 56, 48, 48), menuItem);
    //    GUI.Button(new Rect(160, 56, 48, 48), menuItem);

    //    GUI.Button(new Rect(4, 108, 48, 48), menuItem);
    //    GUI.Button(new Rect(56, 108, 48, 48), menuItem);
    //    GUI.Button(new Rect(108, 108, 48, 48), menuItem);
    //    GUI.Button(new Rect(160, 108, 48, 48), menuItem);

    //    GUI.EndGroup();
    //}

    //For Test Purpose
    //private void Half()
    //{
    //    GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght));
    //    GUI.Button(new Rect(10, 10, 40, 40), menuItem);
    //    GUI.Button(new Rect(60, 10, 40, 40), menuItem);
    //    GUI.Button(new Rect(110, 10, 40, 40), menuItem);
    //    GUI.Button(new Rect(10, 60, 40, 40), menuItem);
    //    GUI.EndGroup();
    //}


    ////For test Purpose
    //private void TestMenu()
    //{

    //    GUI.BeginGroup(new Rect(menuPosX, menuPosY, menuWidth, menuHeght), menuBg);

    //    if (GUI.Button(new Rect(4, 4, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 1");
    //    }

    //    if (GUI.Button(new Rect(56, 4, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 2");
    //    }

    //    if (GUI.Button(new Rect(108, 4, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 3");
    //    }

    //    if (GUI.Button(new Rect(160, 4, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 4");
    //    }

    //    if (GUI.Button(new Rect(4, 56, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 5");
    //    }

    //    if (GUI.Button(new Rect(56, 56, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 6");
    //    }

    //    if (GUI.Button(new Rect(108, 56, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 7");
    //    }

    //    if (GUI.Button(new Rect(160, 56, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 8");
    //    }

    //    if (GUI.Button(new Rect(4, 108, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 9");
    //    }

    //    if (GUI.Button(new Rect(56, 108, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 10");
    //    }

    //    if (GUI.Button(new Rect(108, 108, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 11");
    //    }

    //    if (GUI.Button(new Rect(160, 108, 48, 48), menuItem))
    //    {
    //        Debug.Log("Button 12");
    //    }

    //    GUI.EndGroup();
    //}

}
