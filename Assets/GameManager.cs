using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{

    public int goal;
    public int currentScore;
    public float timeMoving;
    [Range(0,300)]
    public int gameDuration;
    int initialGameDuration;

    public float impulsionTotal;

    public bool gameIsLaunched = false;
    public static GameManager instance;

    public List<GameObject> miniBossList = new List<GameObject>();

    Weapon weapon;

    [ReadOnly]
    public float weaponImpulsivity;


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
        weapon = PlayerController.instance.weaponSelected;

        switch(weapon?.typeOfWeapon)
        {
            case TypeOfWeapon.Semi:
                if(weapon.burst == true)
                {
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + (100f-(weapon.timeBetweenShots/3f))*0.8F) + (weapon.ammunitions/350*100f)/3f;
                }
                else
                {
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + (100f-(weapon.timeBetweenShots/3f))*0.6F) + (weapon.ammunitions/350*100f)/3f;
                }
                break; 
            case TypeOfWeapon.Auto:
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + (100f-(weapon.timeBetweenShots/3f))*2.5f) + (weapon.ammunitions/350*100f)/3f;
                break;
        }
    }

    public void StartTimer()
    {
        gameDuration--;
    }
}
