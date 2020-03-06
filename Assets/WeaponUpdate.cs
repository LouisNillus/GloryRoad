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

    public static WeaponUpdate instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmount.text = Inventory.money.ToString() + "$";

        SetWeaponInfos();
    }

    public void GetWeapon(GameObject go)
    {
        tempToolSlot = go;
        weapon = go.GetComponent<ToolSlot>().weapon;
    }

    public void SetWeaponInfos()
    {
        if (weapon != null)
        {
            if (tempToolSlot.GetComponent<ToolSlot>().isBought == true)
            {
                weaponSprite.sprite = weapon.unlockedSprite;
            }
            else
            {
                weaponSprite.sprite = weapon.lockedSprite;
            }

            weaponType.text = weapon.typeOfWeapon.ToString();
            damages.text = weapon.dmg.ToString("F2");
            fireRate.text = (1f / weapon.timeBetweenShots).ToString("F2") + "/sec";
            dps.text = (1f / weapon.timeBetweenShots * weapon.dmg).ToString("F2");
            range.text = (weapon.bulletLifeTime / weapon.projectileSpeed * 100f).ToString("F2");
            bulletSpeed.text = weapon.projectileSpeed.ToString("F2");
            ammunitions.text = weapon.ammunitions.ToString("F2");
            name.text = weapon.name.ToString();
        }
    }
}
