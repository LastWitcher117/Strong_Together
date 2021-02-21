using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;
    [SerializeField]
    private Vector3 axis = Vector3.forward;

    void Update()
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }
}
