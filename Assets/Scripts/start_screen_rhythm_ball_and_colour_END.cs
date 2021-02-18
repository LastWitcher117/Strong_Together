using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_screen_rhythm_ball_and_colour_END : MonoBehaviour
{
    // change of letter after ball collides with that letter
    public Color colourChange;

    // accessing text component of text (that letter)
    public TextMesh thisLetter;

    public Animator wobble;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "rhythm_ball")
        {
            thisLetter.color = colourChange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "rhythm_ball" && this.tag == "last_letter")
        {
            wobble.SetBool("wobbleTrigger", true);
        }
    }

}
