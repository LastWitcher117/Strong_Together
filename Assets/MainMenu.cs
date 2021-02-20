using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
        
   // LEVEL SELECT //
    public void NightTimeRoot()
    {
        //load scene 1
        SceneManager.LoadScene("FINALSCENE TEST");
    }
    public void ToneLimit()
    {
        //load scene 2
    }

    public void Back()
    {   
        // Back to menu button
        SceneManager.LoadScene("Level_Ann");
    }

}
