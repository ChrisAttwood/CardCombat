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


 
    public Equipment GetEquipment(int level, Slot slot,Color[] colors)
    {
        Equipment equipment = ScriptableObject.CreateInstance(typeof(Equipment)) as Equipment;

        equipment.Slot = slot;
        equipment.Cards = new List<Card>();
        for(int i = 0; i < 4; i++)
        {
            equipment.Cards.Add(Cards[Random.Range(0, Cards.Length)]);
        }
        equipment.BackColour = RandomBackColour();// colors[Random.Range(0, colors.Length)];
        equipment.TopColour = RandomTopColour();// colors[Random.Range(0, colors.Length)];

        switch (slot)
        {
            case Slot.Body:
                equipment.BackSprite = BodyBack[Random.Range(0, BodyBack.Length)];
                equipment.TopSprite = BodyTop[Random.Range(0, BodyTop.Length)];
                break;
            case Slot.Head:
                equipment.BackSprite = HeadBack[Random.Range(0, HeadBack.Length)];
                equipment.TopSprite = HeadTop[Random.Range(0, HeadTop.Length)];
                break;
            case Slot.Legs:
                equipment.BackSprite = LegsBack[Random.Range(0, LegsBack.Length)];
                equipment.TopSprite = LegsTop[Random.Range(0, LegsTop.Length)];
                break;
            case Slot.Primary:
                equipment.BackSprite = PrimaryBack[Random.Range(0, PrimaryBack.Length)];
                equipment.TopSprite = PrimaryTop[Random.Range(0, PrimaryTop.Length)];
                break;
            case Slot.Secondary:
                equipment.BackSprite = SecondaryBack[Random.Range(0, SecondaryBack.Length)];
                equipment.TopSprite = SecondaryTop[Random.Range(0, SecondaryTop.Length)];
                break;
        }

        if (Random.Range(0, 10) == 0)
        {
            equipment.ActionPoints = 1;
        }

        if (Random.Range(0, 10) == 0)
        {
            equipment.ArmourPoints = 5;
        }

        if (Random.Range(0, 10) == 0)
        {
            equipment.TacticPoints = 1;
        }

        equipment.HealthPoints = Random.Range(0, 3) * 5;

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
