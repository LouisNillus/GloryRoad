using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int goal;
    public int currentScore;
    public float timeMoving;
    [Range(0,300)]
    public int gameDuration;
    int initialGameDuration;

    public bool gameIsLaunched = false;
    public static GameManager instance;

    public List<GameObject> miniBossList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        initialGameDuration = gameDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScore == goal)
        {
            //Debug.Log("Win");
        }

        if(gameDuration <= 0)
        {
            PlayerController.instance.gameOverScreen.SetActive(true);
        }
    }

    public void LaunchGame()
    {
        gameIsLaunched = true;
        InvokeRepeating("StartTimer", 0f, 1f);
    }

    public void StartTimer()
    {
        gameDuration--;
    }
}
