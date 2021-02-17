using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDelayPlay : MonoBehaviour
{
    AudioSource myAudio;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(3.23f);
    }
}
