using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect 
{
   
    int Cost;
    int Attack;
    int Defence;
    int Tactics;
    int Actions;
    int Health;
    int Power;


    public CardEffect(Entity attacker, Entity defender, Card card)
    {

        Actions = card.Actions;
        Attack = card.Attack;
        Cost = card.Cost;
        Defence = card.Defence;
        Health = card.Health;
        Power = card.Power;
        Tactics = card.Tactics;

        switch (card.PowerEffect)
        {
            case PowerEffect.ToAttack:
                Attack += attacker.PowerPoints;
                break;
            case PowerEffect.ToDefence:
                Defence += attacker.PowerPoints;
                break;
            case PowerEffect.ToHealth:
                Health += attacker.PowerPoints;
                break;
        }

        if (card.PowerSink)
        {
            attacker.PowerPoints = 0;
        }

        foreach(Buff buff in attacker.Buffs)
        {

            switch(buff.BuffType)
            {
                case BuffType.AttackMultiplier:
                    Attack = Mathf.RoundToInt(Attack * buff.Value);
                    break;
                case BuffType.DefenceMultiplier:
                    Defence = Mathf.RoundToInt(Defence * buff.Value);
                    break;
            }

          
        }





        attacker.Actions -= Cost;
        attacker.Defence += Defence;
        attacker.HealthPoints += Health;
        attacker.PowerPoints += Power;
        attacker.Actions += Actions;
        attacker.DrawCards(Tactics);

        

        defender.Damage(Attack);
    }

}
