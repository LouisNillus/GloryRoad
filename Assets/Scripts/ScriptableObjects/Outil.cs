using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class Outil : ScriptableObject
{

    [Title("General")]

    [TextArea(0, 2)]
    public string name;
    public TypeOfTool typeOfTool;

    [Title("Graphics")]

    [AssetsOnly, Required("Sprite is missing"), PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite lockedSprite;
    [AssetsOnly, Required("Sprite is missing"), PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite unlockedSprite;
    public ParticleSystem particles;

    [Title("Price")]

    [Range(0,1000)]
    public int cost;

    [Title("Damages")]

    [Range(0,100)]
    public int physicDMG;
    [Range(0,100)]
    public int psychoDMG;
}
public enum TypeOfTool {OneShot, StayPressed, Event}
