using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;

public class BeatSpawner : MonoBehaviour
{
    public GameObject[] notes;
    public Transform[] points;

    public RhythmData rhythmData;
    public AudioSource audioSource;

    private float prevTime;
    private List<Beat> beats;
    private List<Onset> onsets;

    public float bpm;
    public float beat = (60 / 145) * 2;
    private float timer;

    void Awake()
    {
        beats = new List<Beat>();
        onsets = new List<Onset>();
    }

    void Update()
    {
        float time = audioSource.time;

        onsets.Clear();
        rhythmData.GetFeatures<Onset>(onsets, prevTime, time);

        /*int counter = 0;
        if (audioSource.isPlaying && time == 0 && counter < 1)
        {
            counter++;
            GameObject note = Instantiate(notes[0], points[0]);
            note.transform.localPosition = Vector3.zero;
            /*GameObject note2 = Instantiate(notes[1], points[1]);
            note.transform.localPosition = Vector3.zero;
            GameObject note3 = Instantiate(notes[2], points[2]);
            note.transform.localPosition = Vector3.zero;
            GameObject note4 = Instantiate(notes[3], points[3]);
            note.transform.localPosition = Vector3.zero;*/
       // }

       /* beats.Clear();

        rhythmData.GetFeatures<Beat>(beats, prevTime, time);

        foreach (Beat beat in beats)
        {
            int lane = Random.Range(0, 4);

            if (lane == 0)
            {
                GameObject note = Instantiate(notes[0], points[0]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (lane == 1)
            {
                GameObject note = Instantiate(notes[1], points[1]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (lane == 2)
            {
                GameObject note = Instantiate(notes[2], points[2]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (lane == 3)
            {
                GameObject note = Instantiate(notes[3], points[3]);
                note.transform.localPosition = Vector3.zero;
            }*/
            //GameObject note = Instantiate(notes[Random.Range(0, 4)], points[Random.Range(0, 4)]);
            //note.transform.localPosition = Vector3.zero;
            /*Debug.Log(beat.strength);
            if (beat.bpm > 0 && onset.strength < 0.5f)
            {
                GameObject note = Instantiate(notes[3], points[3]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (onset.strength > 0.5 && onset.strength < 1)
            {
                GameObject note = Instantiate(notes[2], points[2]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (onset.strength > 1 && onset.strength < 2.5f)
            {
                GameObject note = Instantiate(notes[1], points[1]);
                note.transform.localPosition = Vector3.zero;
            }
            else if (onset.strength > 2.5f)
            {
                GameObject note = Instantiate(notes[0], points[0]);
                note.transform.localPosition = Vector3.zero;
            }*/

            foreach (Onset onset in onsets)
            {
                Debug.Log(onset.strength);
                if (onset.strength > 0 && onset.strength < 0.5f)
                {
                    GameObject note = Instantiate(notes[3], points[3]);
                    note.transform.localPosition = Vector3.zero;
                }
                else if (onset.strength > 0.5 && onset.strength < 1)
                {
                    GameObject note = Instantiate(notes[2], points[2]);
                    note.transform.localPosition = Vector3.zero;
                }
                else if (onset.strength > 1 && onset.strength < 2.5f)
                {
                    GameObject note = Instantiate(notes[1], points[1]);
                    note.transform.localPosition = Vector3.zero;
                }
                else if (onset.strength > 2.5f)
                {
                    GameObject note = Instantiate(notes[0], points[0]);
                    note.transform.localPosition = Vector3.zero;
                }

            //GameObject note = Instantiate(notes[Random.Range(0, 4)], points[Random.Range(0, 4)]);
            //note.transform.localPosition = Vector3.zero;
        }

        prevTime = time;

        /*if (timer > beat)
        {
            GameObject note = Instantiate(notes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            note.transform.localPosition = Vector3.zero;
            timer -= beat;
        }
        timer += Time.deltaTime;*/
    }
}
