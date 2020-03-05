using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class Victime : ScriptableObject
{
    [Title("General")]

    public string name;

    [Required("Faction is needed")]
    public Faction faction;

    [TextArea(0, 3)]
    public string description;

    [Title("Stats")]

    [Range(0,100)]
    public float hp;
    [Range(0,3)]
    public float physicResistance;
    [Range(0,3)]
    public float psychoResistance;

    [Range(0, 3)]
    public float headMultiplier;
    [Range(0, 3)]
    public float chestMultiplier;
    [Range(0, 3)]
    public float armsMultiplier;
    [Range(0, 3)]
    public float legsMultiplier;

    public Weakness weakness;

    [Title("Dialogues")]

    public string[] sentences;

}
[System.Flags]
public enum Weakness
{
    None = 0,
    Head = 1,
    Chest = 2,
    Arms = 4,
    Legs = 8,
}

    /*public void Test()
    {
        if(bite.HasFlag(Bite.A))
        {
            bite = Bite.A | Bite.C;
        }
    }*/