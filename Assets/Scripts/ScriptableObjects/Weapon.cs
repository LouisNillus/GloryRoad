using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{

    public string name;

    public TypeOfWeapon typeOfWeapon;
    public int ammunitions;
    public float projectileSpeed;
    public float bulletLifeTime;
    public float timeBetweenShots;
    public int dmg;
    public int howManyProjectiles;
    public int angleBetweenProjectiles;

    public int cost;

    [PreviewField]
    public Sprite lockedSprite;
    [PreviewField]
    public Sprite unlockedSprite;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum TypeOfWeapon {Auto, Semi, Spread, Burst, Laser}