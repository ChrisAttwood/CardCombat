using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Zone : ScriptableObject
{

    public string Title;

    public Sprite Sprite;

    public int Level;

    public Color BackColor = Color.grey;
    public Color TopColor = Color.white;

    public List<Equipment> Get()
    {
        List<Equipment> equipment = new List<Equipment>();

   

        equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Primary, BackColor, TopColor));
        equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Legs, BackColor, TopColor));

      

        if (Random.Range(Level, 30) > 10)
        {
            equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Body, BackColor, TopColor));

            if (Random.Range(Level, 20) > 10)
            {
                equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Secondary, BackColor, TopColor));

                if (Random.Range(Level, 15) > 10)
                {
                    equipment.Add(EquipmentManager.instance.GetEquipment(Level, Slot.Head, BackColor, TopColor));
                }
            }

           
        }

       

            
        


        return equipment;

    }

}

