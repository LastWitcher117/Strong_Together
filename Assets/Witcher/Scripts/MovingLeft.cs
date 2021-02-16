using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
