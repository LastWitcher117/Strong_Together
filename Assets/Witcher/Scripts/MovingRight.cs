using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRight : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
