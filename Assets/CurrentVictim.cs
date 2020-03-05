using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CurrentVictim : MonoBehaviour
{
    public float hp;

    [Space(30)]

    [Required("Victim is needed"), DrawScriptable]
    public Victime victim;

    [ReadOnly]
    public float damagesDealt;


    // Start
    void Start()
    {
        hp = victim.hp;
    }

    // Update
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0) && ToolPicking.instance.currentTool.typeOfTool == TypeOfTool.OneShot)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if(hit.collider != null)
            {

                switch(hit.collider.gameObject.name)
                {
                    case "HEAD":
                        TakeDamages(victim.weakness.HasFlag(Weakness.Head), victim.headMultiplier);
                        break;    
                    case "CHEST": 
                        TakeDamages(victim.weakness.HasFlag(Weakness.Chest), victim.chestMultiplier);
                        break;    
                    case "ARMS":  
                        TakeDamages(victim.weakness.HasFlag(Weakness.Arms), victim.armsMultiplier);
                        break;    
                    case "LEGS":  
                        TakeDamages(victim.weakness.HasFlag(Weakness.Legs), victim.legsMultiplier);
                        break;
                }
            }
        }*/

        hp = Mathf.Clamp(hp, 0f, 100f);
    }

    public void TakeDamages(bool hasWeakness, float multiplier)
    {
        if(hasWeakness)
        {
            //damagesDealt = (ToolPicking.instance.currentTool.physicDMG / victim.physicResistance) * multiplier;
        }
        else
        {
            //damagesDealt = (ToolPicking.instance.currentTool.physicDMG / victim.physicResistance);
        }

        hp -= damagesDealt;
    }

}
