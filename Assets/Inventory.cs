﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Inventory : MonoBehaviour
{
    public static int money = 25000;

    [ReadOnly]
    public int argent;


    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        argent = money;

        if(Input.GetKey(KeyCode.O))
        {
            money += 100;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            shop.SetActive(true);
        }
    }
}
