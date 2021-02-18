using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] notes;
    public Transform[] points;

    public float bpm;
    public float beat = (60/144) * 2;
    private float timer;

    void Start()
    {

    }

    void Update()
    {
        if (timer > beat)
        {
            GameObject note = Instantiate(notes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            note.transform.localPosition = Vector3.zero;
            timer -= beat;
        }
        timer += Time.deltaTime;
    }
}
