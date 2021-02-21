using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [Header("WITCHER")]
    int multiplier = 1;
    int streak = 0;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 25);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Multiplier", 1);
        PlayerPrefs.SetInt("NotesHit", 0);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        //Destroy(coll.gameObject);
    }

    public void AddStreak()
    {   
        if (PlayerPrefs.GetInt("RockMeter") + 1 < 50)
        {
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 1);
        }

        streak++;
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;

        if (streak > PlayerPrefs.GetInt("HighStreak"))
        {
            PlayerPrefs.SetInt("HighStreak", streak);
        }

        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") +1);


        UpdateGUI();
    }

    public void ResetStreak()
    {
        PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") - 2);

        if (PlayerPrefs.GetInt("RockMeter") < 0)
        {
            Lose();
        }
            streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void Lose()
    {
        //SceneManager.LoadScene("LoseScreen");
    }

    public void Win()
    {
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }

        SceneManager.LoadScene("Win_Nightime");

    } public void Win1()
    {
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }

        SceneManager.LoadScene("Win_Timeline");
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multiplier", multiplier);
    }

    



    public int GetScore(int score)
    {
        return (100 + score) * multiplier;
    }
}
