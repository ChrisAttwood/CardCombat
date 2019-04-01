using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EquipmentManager : MonoBehaviour
{

    public static EquipmentManager instance;

 

 //   public ZoneSet[] ZoneSets;

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


    //public Equipment[] Get(string name,int items)
    //{
    //    var zoneSet = ZoneSets.First(x => x.Name == name);
    //    List<Equipment> equipment = new List<Equipment>();

    //    for(int i = 0;i< items; i++)
    //    {
    //        var e = zoneSet.Equipment[Random.Range(0, zoneSet.Equipment.Length)];
    //        if(!equipment.Any(x=>x.Slot == e.Slot))
    //        {
    //            equipment.Add(e);
    //        }
    //    }

    //    return equipment.ToArray();

    //}

    //public List<Equipment> StartingSet(int items)
    //{
    //    List<Equipment> equipment = new List<Equipment>();
    //    var w = StartWeapons[Random.Range(0, StartWeapons.Length)];
    //    equipment.Add(w);

    //    for (int i = 0; i < items; i++)
    //    {
    //        var e = StartEquipment[Random.Range(0, StartEquipment.Length)];
    //        if (!equipment.Any(x => x.Slot == e.Slot))
    //        {
    //            equipment.Add(e);
    //        }
    //    }

    //    return equipment;
    //}

}

//[System.Serializable]
//public class ZoneSet
//{
//    public string Name;

//    public Equipment[] Equipment;
    
//}


