﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class Buff : ScriptableObject
{
    
    public float MultiplierValue;
    public int TickAmount;
    public Period Period;
    public BuffType BuffType;
    public bool Offensive;
    public string Description;

    
}





