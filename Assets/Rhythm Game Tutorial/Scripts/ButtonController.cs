using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    
    public GameObject note;

    public bool createMode;


    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (createMode)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                Instantiate(note, transform.position, Quaternion.identity);
            }
        }*/
        //else
        //{

            if (Input.GetKeyDown(keyToPress))
            {
                theSR.sprite = pressedImage;
            }

            if (Input.GetKeyUp(keyToPress))
            {
                theSR.sprite = defaultImage;
            }
        //}
    }
}
