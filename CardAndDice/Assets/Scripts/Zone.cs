using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Zone : ScriptableObject
{

    public string Title;

    public Sprite Sprite;

    public int Level;

 
    public List<Equipment> Get()
    {
        List<Equipment> equipment = new List<Equipment>();

   

        equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Primary));
        equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Legs));

        if (Random.Range(Level, 20) > 10)
        {
            equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Secondary));
        }

        if (Random.Range(Level, 30) > 10)
        {
            equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Body));
        }

        if (Random.Range(Level, 15) > 10)
        {
            equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Head));
        }

            
        


        return equipment;

    }

}

