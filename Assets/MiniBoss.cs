using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MiniBoss : ScriptableObject
{
    [Range(0,500)]
    public int moneyReward;
    [Range(0,1000)]
    public int hp;
    [Range(0,100)]
    public int fatalRange;
}
