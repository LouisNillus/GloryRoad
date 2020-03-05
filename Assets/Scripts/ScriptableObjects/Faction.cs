using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class Faction : ScriptableObject
{
    [Title("General")]

    public string name;

    [Title("Graphics")]

    [AssetsOnly, Required("Sprite is missing"), PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public Sprite flag;




}
