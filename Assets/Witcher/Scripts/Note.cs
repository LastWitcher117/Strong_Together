using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Note rotation to make it look fancy - float rotationSpeed = 50.0f;

    void Start()
    {
        rb.velocity = new Vector3(-speed, 0);
    }

    void Update()
    {
        //Note rotation for fun to make it look fancy - transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}
