using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            Debug.Log("KABOOM");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        active = true;

        if(coll.gameObject.tag == "Note")
        {
            note = coll.gameObject;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        active = false;
    }
}
