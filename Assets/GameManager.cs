using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{

    public int goal;
    public int currentScore;
    public float timeMoving;
    public float totalImpulsionForTimeMoving;
    [Range(0,300)]
    public int gameDuration;
    [ReadOnly, SerializeField]
    int initialGameDuration;
    [ReadOnly, SerializeField]
    float totalAmmosImpulsion;
    [ReadOnly, SerializeField]
    float totalLifeUsed;

    int initialLifeAmount;

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

        if(Input.GetKeyDown(KeyCode.F))
        {
            EndGame();
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
        initialLifeAmount = PlayerController.instance.hp;

        switch (weapon.typeOfWeapon)
        {
            case TypeOfWeapon.Semi:
                if(weapon.burst == true)
                {
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + (weapon.howManyProjectiles/10f * 100f * 2f) + ((100f-(weapon.timeBetweenShots/3f*100f))*1.2f) + (weapon.ammunitions/300*100f))/4f;
                }
                else
                {
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + ((100f-(weapon.timeBetweenShots/3f*100f))*0.6f) + (weapon.ammunitions/300*100f))/4f;
                }
                break; 
            case TypeOfWeapon.Auto:
                    weaponImpulsivity = ((weapon.dmg/400 *100f) + ((100f-(weapon.timeBetweenShots/3f*100f))*2f) + (weapon.ammunitions/300*100f))/4f;
                break;
        }
    }

    public void EndGame()
    {
        CancelInvoke("StartTimer");
        totalImpulsionForTimeMoving = timeMoving / initialGameDuration * 100f;
        totalAmmosImpulsion = (float)PlayerController.instance.ammos / (float)weapon.ammunitions * 100f;
        totalLifeUsed = initialLifeAmount - PlayerController.instance.hp;
    }


    public void StartTimer()
    {
        gameDuration--;
    }
}
