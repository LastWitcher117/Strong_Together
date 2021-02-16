using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 150;
    public int scorePerPerfectNote = 200;


    public int currentMultiplier;
    public int multiplierTracker = 0;
    public int[] multiplierThreshholds;

    public Text scoreText;
    public Text multipliertText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                BS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThreshholds.Length)
        {

            multiplierTracker++;
            if (multiplierTracker >= multiplierThreshholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multipliertText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;

        scoreText.text = "Score: " + currentScore;

    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed!");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multipliertText.text = "Multiplier: X" + currentMultiplier;
    }
}
