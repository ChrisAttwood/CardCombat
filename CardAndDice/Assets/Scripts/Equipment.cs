using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Equipment : ScriptableObject
{
    public string Title;
    public Sprite Sprite;
    public Slot Slot;
    public List<Card> Cards;
    public int ActionPoints;
    public int TacticPoints;
    public int ArmourPoints;
    public int HealthPoints;

}


