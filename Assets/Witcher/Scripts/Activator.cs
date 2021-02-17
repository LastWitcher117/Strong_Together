using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer sr;

    public KeyCode key;
    bool active = false;
    GameObject note;
    Color old;
    public bool createMode;
    public GameObject n;


    private void Start()
    {
        old = sr.color;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n,transform.position,Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                AddScore();
            }
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

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
