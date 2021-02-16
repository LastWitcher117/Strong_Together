using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_screen_rhythm_ball_and_colour : MonoBehaviour
{
    // change of letter after ball collides with that letter
    public Color colourChange;

    // accessing text component of text (that letter)
    public TextMesh thisLetter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "rhythm_ball")
        {
            thisLetter.color = colourChange;

        }
    }
    
}
