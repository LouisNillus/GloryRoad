using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ToolSlot : MonoBehaviour
{
    [DrawScriptable]
    public Weapon weapon;

    [Space(30)]

    [Title("References")]

    public Image visual;
    public Text cost;
    public Button buyButton;
    public Text buttonText;

    [HideInInspector]
    public bool isBought;
    [HideInInspector]
    public bool isSelected = true;


    // Start is called before the first frame update
    void Start()
    {
        weapon.cost = (int)(weapon.dmg * weapon.ammunitions + weapon.dmg * (1f / weapon.timeBetweenShots) * weapon.howManyProjectiles + weapon.projectileSpeed * weapon.bulletLifeTime);

        cost.text = weapon.cost.ToString() + "$";
        visual.sprite = weapon.lockedSprite;

        if(weapon.name == "Glock")
        {
            BuyTool();
            UseTool();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyLife(int cost)
    {
        if(Inventory.money >= cost)
        {
            Inventory.money -= cost;
            PlayerController.instance.hp++;
        }
    }

    public void BuyTool()
    {
        if(Inventory.money >= weapon.cost && isBought == false)
        {
            Inventory.money -= weapon.cost;
            visual.sprite = weapon.unlockedSprite;
            cost.text = weapon.name;
            buttonText.text = "USE";
            buttonText.color = Color.yellow;
            isBought = true;
        }
    }

    public void UseTool()
    {
        isSelected = false;

        if(isBought == true && isSelected == false)
        {
            PlayerController.instance.weaponSelected = weapon;
            ToolPicking.instance.currentWeapon = weapon;
            if (PlayerController.instance.ammos != weapon.ammunitions)
            {
                PlayerController.instance.ammos = weapon.ammunitions;
            }

            ToolPicking.instance.ChangeUseState();
            WeaponUpdate.instance.GetWeapon(this.gameObject);

            buttonText.text = "SELECTED";
            buttonText.color = Color.green;
            isSelected = true;
        }
    }
}
