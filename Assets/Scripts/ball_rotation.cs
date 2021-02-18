using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_rotation : MonoBehaviour
{
    public int rotation_speed;
    public Vector3 axis = Vector3.forward;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, rotation_speed * Time.deltaTime);
    }

}
