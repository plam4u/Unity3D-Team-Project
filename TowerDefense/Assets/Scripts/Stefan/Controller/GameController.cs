using UnityEngine;
using System;
using System.Collections;

//This class is to conttrolling the logic of a game, like money, spawn's and etc.
//This class need TO BE EDITING FROM EVERYONE WHO IS INVOLVED :)
public class GameController : MonoBehaviour
{

    //How much money will start a game
    private static int _money;
    private static int _score;
    private static bool _buildMode = false;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    //Propert-is
    //get and set the money 
    public static int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }

    //get and set the score
    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
    
    //Constructor with no instantiation to prevent instanse
    public GameController()
    {
        Debug.Log("this class cannot be instantiated");
    }
   
    //Set the starting value of the money
    private static void StartMoney(int money)
    {
        _money = money;
    }

    private static void StartScore(int score)
    {
        _score = score;
    }
}
