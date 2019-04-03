using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Equipment[] Equipment;


    public Stack<Card> Deck { get; set; }

    public List<Card> Hand { get; set; }

    public List<Card> Spent { get; set; }

    public List<Buff> Buffs { get; set; }
    public List<Buff> SpentBuffs { get; set; }

    public int Actions { get; set; }
    public int Defence { get; set; }
    public int ActionPoints { get; set; }
    public int TaticPoints { get; set; }
    public int ArmourPoints { get; set; }
    public int HealthPoints { get; set; }
    public int PowerPoints { get; set; }

    private void Awake()
    {
      
        Defence = 0;
        Actions = 0;
        Buffs = new List<Buff>();
        SpentBuffs = new List<Buff>();
    }

    public void BeginTurn()
    {
        Defence = ArmourPoints;
        Actions = ActionPoints;
    }

    void Draw()
    {
        foreach(Slot s in System.Enum.GetValues(typeof(Slot)))
        {
            var e = Equipment.FirstOrDefault(x => x.Slot == s);
            if (e != null)
            {
                transform.GetChild((int)s).GetComponent<SpriteRenderer>().sprite = e.Sprite;
            }
        }
    }

    public void SetUp()
    {
        var deck = new List<Card>();

        foreach(var e in Equipment)
        {
            foreach (var c in e.Cards)
            {
                deck.Add(c);
            }
        }

        Deck = new Stack<Card>(deck.OrderBy(a => System.Guid.NewGuid()).ToList());

        TaticPoints = 3 + Equipment.Sum(x => x.TacticPoints);
        ActionPoints = 3 + Equipment.Sum(x => x.ActionPoints);
        ArmourPoints = Equipment.Sum(x => x.ArmourPoints);
        HealthPoints = 10 + Equipment.Sum(x => x.HealthPoints);
        Defence = ArmourPoints;
        Draw();
    }


    public void DrawHand()
    {
        Hand = new List<Card>();

        for(int i = 0; i < TaticPoints; i++)
        {
            if (Deck.Count == 0)
            {
                Deck = new Stack<Card>(Spent.OrderBy(a => System.Guid.NewGuid()).ToList());
                Spent = new List<Card>();
            }
            Hand.Add(Deck.Pop());
        }
    }

    public void ClearHand()
    {
        if (Spent == null)
        {
            Spent = new List<Card>();
        }
        foreach (Card card in Hand)
        {
           
            Spent.Add(card);
        }
        Hand = null;
    }

    public void Spend(Card card)
    {
        Hand.Remove(card);
        if(Spent == null)
        {
            Spent = new List<Card>();
        }

        Spent.Add(card);

    }

    public void StoreBuffs(Buff[] buffs)
    {
        Buffs.AddRange(buffs);
    }


    public void CleanBuffs()
    {
        foreach (Buff buff in SpentBuffs)
        {
            Buffs.Remove(buff);
        }
        SpentBuffs = new List<Buff>();
    }



    public void TickBuffs()
    {
        foreach (Buff buff in Buffs)
        {
            switch (buff.BuffType)
            {
                case BuffType.TickHealthChange:
                    HealthPoints += buff.Amount;
                    if (HealthPoints < 0)
                    {
                        HealthPoints = 0;
                    }
                    break;
                case BuffType.TickPowerChange:
                    PowerPoints += buff.Amount;
                    if (PowerPoints < 0)
                    {
                        PowerPoints = 0;
                    }
                    break;

            }
        }
    }


    public void Damage(int amount)
    {
        if(amount<= Defence)
        {
            Defence -= amount;
        }
        else
        {
            HealthPoints -= (amount - Defence);
            Defence = 0;
        }

        if (HealthPoints < 0)
        {
            HealthPoints = 0;
        }
    }

    public void DrawCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (Deck.Count == 0)
            {
                Deck = new Stack<Card>(Spent.OrderBy(a => System.Guid.NewGuid()).ToList());
                Spent = new List<Card>();
            }
            if (Deck.Count > 0)
            {
                Hand.Add(Deck.Pop());
            }
           
        }
    }

}
