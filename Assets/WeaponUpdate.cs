using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpdate : MonoBehaviour
{

    public Weapon weapon;
    public Text moneyAmount;

    public Text name;
    public Text weaponType;
    public Text damages;
    public Text fireRate;
    public Text dps;
    public Text range;
    public Text bulletSpeed;
    public Text ammunitions;

    public Image weaponSprite;

    GameObject tempToolSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount.text = Inventory.money.ToString() + "$";

        if(weapon != null)
        {
            if(tempToolSlot.GetComponent<ToolSlot>().isBought == true)
            {
                weaponSprite.sprite = weapon.unlockedSprite;
            }
            else
            {
                weaponSprite.sprite = weapon.lockedSprite;
            }

            weaponType.text = weapon.typeOfWeapon.ToString();
            damages.text = weapon.dmg.ToString();
            fireRate.text = (1f/weapon.timeBetweenShots).ToString() + "/sec";
            dps.text = (1f / weapon.timeBetweenShots * weapon.dmg).ToString();
            range.text = (weapon.bulletLifeTime/weapon.projectileSpeed*100f).ToString();
            bulletSpeed.text = weapon.projectileSpeed.ToString();
            ammunitions.text = weapon.ammunitions.ToString();
            name.text = weapon.name.ToString();
        }
    }

    public void GetWeapon(GameObject go)
    {
        tempToolSlot = go;
        weapon = go.GetComponent<ToolSlot>().weapon;
    }
}
