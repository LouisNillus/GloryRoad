using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{

    public string name;

    public TypeOfWeapon typeOfWeapon;

    public bool burst;

    [Range(0,300)]
    public int ammunitions;
    [Range(0,100)]
    public float projectileSpeed;
    [Range(0,3)]
    public float bulletLifeTime;
    [Range(0,3)]
    public float timeBetweenShots;
    [Range(0,400)]
    public int dmg;
    [Range(0,10)]
    public int howManyProjectiles;
    [Range(0,180)]
    public int angleBetweenProjectiles;

    [Range(0, 10), ShowIf("burst", true)]
    public int burstQuantity;

    [Range(0, 1), ShowIf("burst", true)]
    public float burstInterval;

    [Range(0,10000)]
    public int cost;

    [PreviewField]
    public Sprite lockedSprite;
    [PreviewField]
    public Sprite unlockedSprite;
    [PreviewField]
    public Sprite topViewSprite;

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
public enum TypeOfWeapon {Auto, Semi}