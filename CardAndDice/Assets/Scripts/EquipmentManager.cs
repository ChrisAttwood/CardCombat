using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EquipmentManager : MonoBehaviour
{

    public static EquipmentManager instance;


    public Card[] Cards;


    public Sprite[] PrimaryTop;
    public Sprite[] PrimaryBack;

    public Sprite[] SecondaryTop;
    public Sprite[] SecondaryBack;

    public Sprite[] HeadTop;
    public Sprite[] HeadBack;

    public Sprite[] BodyTop;
    public Sprite[] BodyBack;

    public Sprite[] LegsTop;
    public Sprite[] LegsBack;

  



    public Zone Player;
    public Zone Castle;
    public Zone[] Zones;

    private void Awake()
    {
        instance = this;
    }


    public Zone Get(int level)
    {
        var zones = Zones.Where(x => x.Level < level).ToArray();
        return zones[Random.Range(0, zones.Length)];
    }


 
    public Equipment GetEquipment(int level, Slot slot)
    {
        Equipment equipment = ScriptableObject.CreateInstance(typeof(Equipment)) as Equipment;

        equipment.Slot = slot;
        equipment.Cards = new List<Card>();
        for(int i = 0; i < 4; i++)
        {
            equipment.Cards.Add(Cards[Random.Range(0, Cards.Length)]);
        }
        equipment.BackColour = RandomBackColour();
        equipment.TopColour = RandomTopColour();

        switch (slot)
        {
            case Slot.Body:
                equipment.BackSprite = BodyBack[Random.Range(0, BodyBack.Length)];
                equipment.TopSprite = BodyTop[Random.Range(0, BodyTop.Length)];
                equipment.HealthPoints = 20;
                break;
            case Slot.Head:
                equipment.BackSprite = HeadBack[Random.Range(0, HeadBack.Length)];
                equipment.TopSprite = HeadTop[Random.Range(0, HeadTop.Length)];
                equipment.HealthPoints = 10;
                equipment.TacticPoints = 1;
                equipment.ActionPoints = 1;
                break;
            case Slot.Legs:
                equipment.BackSprite = LegsBack[Random.Range(0, LegsBack.Length)];
                equipment.TopSprite = LegsTop[Random.Range(0, LegsTop.Length)];
                equipment.HealthPoints = 20;
                break;
            case Slot.Primary:
                equipment.BackSprite = PrimaryBack[Random.Range(0, PrimaryBack.Length)];
                equipment.TopSprite = PrimaryTop[Random.Range(0, PrimaryTop.Length)];
                equipment.Cards.Add(Cards[Random.Range(0, Cards.Length)]);
                equipment.Cards.Add(Cards[Random.Range(0, Cards.Length)]);
                break;
            case Slot.Secondary:
                equipment.BackSprite = SecondaryBack[Random.Range(0, SecondaryBack.Length)];
                equipment.TopSprite = SecondaryTop[Random.Range(0, SecondaryTop.Length)];
                equipment.ArmourPoints = 5;
                
                break;
        }


        return equipment;
    }

    Color RandomBackColour()
    {
        return new Color(Random.Range(3, 6) * 0.1f, Random.Range(3, 6) * 0.1f, Random.Range(3, 6) * 0.1f);
    }

    Color RandomTopColour()
    {
        return new Color(Random.Range(5, 8) * 0.1f, Random.Range(5, 8) * 0.1f, Random.Range(5, 8) * 0.1f);
    }
}
