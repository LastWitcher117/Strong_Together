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

    public int scorePerNote = 25;
    public int scorePerGoodNote = 50;
    public int scorePerPerfectNote = 100;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    private Animator animator = null;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
        old = sr.color;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                animator.SetTrigger("Hit");
            }
            if (Input.GetKeyDown(key) && active)
            {
                if (Mathf.Abs(note.transform.position.x) > 0.25)
                {
                    Debug.Log("Hit");
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    note.SetActive(false);
                    gm.GetComponent<Game_Manager>().AddStreak();
                    NormalHit();
                }
                if (Mathf.Abs(note.transform.position.x) > 0.05f)
                {
                    Debug.Log("Good");
                    //GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    note.SetActive(false);
                    gm.GetComponent<Game_Manager>().AddStreak();
                    GoodHit();
                }
                else
                {
                    Debug.Log("Perfect");
                    //GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    note.SetActive(false);
                    gm.GetComponent<Game_Manager>().AddStreak();
                    PerfectHit();
                }
                //Destroy(note);
                //note.SetActive(false);
                //gm.GetComponent<Game_Manager>().AddStreak();
                //AddScore();
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
        if (coll.gameObject.tag == "Note" && coll.gameObject.activeSelf)
        {
            Debug.LogWarning("Exit funktioniert");
            active = false;
            gm.GetComponent<Game_Manager>().ResetStreak();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            note.SetActive(false);
            
        }
        active = false;
    }

    public void NormalHit()
    {
        AddScore(scorePerNote);

    }

    public void GoodHit()
    {
        AddScore(scorePerGoodNote);
    }

    public void PerfectHit()
    {
        AddScore(scorePerPerfectNote);
    }

    void AddScore(int score)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<Game_Manager>().GetScore(score));
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
