using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // create a key-value pair in registry (player prefs)
    // HIGH_SCORE is key, "High Sccore" is string name
    private const string HIGH_SCORE = "High Score";
    private void Awake()
    {
        MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    void MakeSingleInstance()
    {
        // we need use "if" to destroy clone of Game Manager
        // if dont have "if", everytime we click MENU button
        // a Game Manager obj is created. Here, we check if there's an
        // Game Manager -> destroy it if any!
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Function to save player's score
    public void SetHighScore(int score){
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    //Function to get the player's score saved in registry
    public int GetHighScore(){
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    void IsGameStartedForTheFirstTime(){
        if(!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime")){
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
}
