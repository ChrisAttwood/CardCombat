using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class Buff : ScriptableObject
{
    
    public float Value;
    public int Amount;
    public Period Period;
    public BuffType BuffType;
    public bool Offensive;
    public string Description;

    
}





