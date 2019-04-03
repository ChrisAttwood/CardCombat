using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class CardSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        Card b = (Card)obj;
        info.AddValue("Actions", b.Actions);
        info.AddValue("Attack", b.Attack);
        info.AddValue("Buffs", b.Buffs);
        info.AddValue("Cost", b.Cost);
        info.AddValue("Defence", b.Defence);
        info.AddValue("Description", b.Description);
        info.AddValue("Health", b.Health);
        info.AddValue("name", b.name);
        info.AddValue("Tactics", b.Tactics);
        info.AddValue("Title", b.Title);
        info.AddValue("Power", b.Power);
        info.AddValue("PowerEffect", b.PowerEffect);
        info.AddValue("PowerSink", b.PowerSink);
        info.AddValue("PowerRequired", b.PowerRequired);


    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        Card b = ScriptableObject.CreateInstance(typeof(Card)) as Card;
        b.Actions = (int)info.GetValue("Actions", typeof(int));
        b.Attack = (int)info.GetValue("Attack", typeof(int));
        b.Buffs = (Buff[])info.GetValue("Buffs", typeof(Buff[]));
      
       
      
        b.Cost = (int)info.GetValue("Cost", typeof(int));
        b.Defence = (int)info.GetValue("Defence", typeof(int));
        b.Description = (string)info.GetValue("Description", typeof(string));
        b.Health = (int)info.GetValue("Health", typeof(int));
        b.name = (string)info.GetValue("name", typeof(string));
        b.Tactics = (int)info.GetValue("Tactics", typeof(int));
        b.Title = (string)info.GetValue("Title", typeof(string));
        b.Power = (int)info.GetValue("Power", typeof(int));
        b.PowerEffect = (PowerEffect)info.GetValue("PowerEffect", typeof(PowerEffect));
        b.PowerSink = (bool)info.GetValue("PowerSink", typeof(bool));
        b.PowerRequired = (int)info.GetValue("PowerRequired", typeof(int));

        obj = b;
        return obj;
    }
}
