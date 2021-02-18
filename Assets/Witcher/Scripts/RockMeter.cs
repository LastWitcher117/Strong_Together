using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{
    float rm;
    GameObject Needle;
    
    void Start()
    {
        Needle = transform.Find("Needle").gameObject;
    }

    void Update()
    {
        rm = PlayerPrefs.GetInt("RockMeter");

        Needle.transform.localPosition = new Vector3((rm-25)/25, 0, 0);
    }
}
