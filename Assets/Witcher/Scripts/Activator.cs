using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode key;
    bool active = false;
    GameObject note, gm;
    Color old;
    public bool createMode;
    public GameObject n;


    private void Start()
    {
        gm = GameObject.Find("GameManager");
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
                sr.sprite = pressedImage;
            }
            if (Input.GetKeyUp(key))
            {
                sr.sprite = defaultImage;
            }
            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
            }
            else if ((Input.GetKeyDown(key) && !active))
            {
                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.LogWarning("Enter funktioniert");
        if (coll.gameObject.tag == "WinNote")
        {
            gm.GetComponent<Game_Manager>().Win();
        }

        if (coll.gameObject.tag == "Note")
        {
            note = coll.gameObject;
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        Debug.LogWarning("Exit funktioniert");
        active = false;
        gm.GetComponent<Game_Manager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<Game_Manager>().GetScore());
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
