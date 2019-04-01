using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EquipmentSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Equipment b = (Equipment)obj;
        info.AddValue("ActionPoints", b.ActionPoints);
        info.AddValue("ArmourPoints", b.ArmourPoints);
        info.AddValue("Cards", b.Cards);
        info.AddValue("HealthPoints", b.HealthPoints);
        info.AddValue("Slot", b.Slot);
        info.AddValue("TacticPoints", b.TacticPoints);
        info.AddValue("Title", b.Title);
        info.AddValue("name", b.name);
        info.AddValue("Sprite", b.Sprite.name);


    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Equipment b = ScriptableObject.CreateInstance(typeof(Equipment)) as Equipment;
        b.ActionPoints = (int)info.GetValue("ActionPoints", typeof(int));
        b.ArmourPoints = (int)info.GetValue("ArmourPoints", typeof(int));
        b.Cards = (List<Card>)info.GetValue("Cards", typeof(List<Card>));
        b.HealthPoints = (int)info.GetValue("HealthPoints", typeof(int));
        b.Slot = (Slot)info.GetValue("Slot", typeof(Slot));
        b.TacticPoints = (int)info.GetValue("TacticPoints", typeof(int));
        b.Title = (string)info.GetValue("Title", typeof(string));
        b.name = (string)info.GetValue("name", typeof(string));
        b.Sprite = Resources.Load<Sprite>("Sprites/" + (string)info.GetValue("Sprite", typeof(string)));
        obj = b;
        return obj;
    }
}
