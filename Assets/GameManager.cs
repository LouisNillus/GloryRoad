using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int goal;
    public int currentScore;

    public List<GameObject> miniBossList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore == goal)
        {
            //Debug.Log("Win");
        }
    }
}
