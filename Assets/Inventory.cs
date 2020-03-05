using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Inventory : MonoBehaviour
{
    public static int money = 15000;

    [ReadOnly]
    public int argent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        argent = money;
    }
}
