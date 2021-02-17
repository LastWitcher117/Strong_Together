using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundHit : MonoBehaviour
{
    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAudio.Play();
    }
}
