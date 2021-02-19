using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject note;
    public GameObject[] laneStart;
    public float bpm;
    private float lastTime, deltaTime, timer;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, 4);
        deltaTime = GetComponent<AudioSource>().time - lastTime;
        timer += deltaTime;

        if (timer >= (60f/bpm))
        {
            ((GameObject)Instantiate(note, laneStart[rand].transform.position, laneStart[rand].transform.rotation)).GetComponent<Transform>().parent = GetComponent<Transform>();
            timer -= (60f / bpm);

        }

        lastTime = GetComponent<AudioSource>().time;
    }
}
