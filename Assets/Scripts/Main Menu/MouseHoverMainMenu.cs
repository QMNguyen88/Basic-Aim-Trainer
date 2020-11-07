﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverMainMenu : MonoBehaviour
{
    public string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
