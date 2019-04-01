using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Card : ScriptableObject
{
    public string Title;
    [TextArea(3, 10)]
    public string Description;

    public int Cost;
    public int Attack;
    public int Defence;
    public int Tactics;
    public int Actions;
    public int Health;
    public int Power;

    public PowerEffect PowerEffect;
    public bool PowerSink;
    public int PowerRequired;


    public Buff[] Buffs;


    public Card GetCopy()
    {
        Card card = ScriptableObject.CreateInstance(typeof(Card)) as Card;
        card.Actions = Actions;
        card.Attack = Attack;
        card.Buffs = Buffs;
        card.Cost = Cost;
        card.Defence = Defence;
        card.Description = Description;
        card.Health = Health;
        card.name = name;
        card.Power = Power;
        card.PowerEffect = PowerEffect;
        card.PowerRequired = PowerRequired;
        card.PowerSink = PowerSink;
        card.Tactics = Tactics;
        card.Title = Title;
        return card;
    }
}


