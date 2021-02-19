using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Note rotation to make it look fancy - float rotationSpeed = 50.0f;

    void Update()
    {
        //Note rotation for fun to make it look fancy - transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
    }

    
}
