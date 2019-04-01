using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

using UnityEngine;

public class BuffSerializationSurrogate : ISerializationSurrogate
{ 

    public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context)
    {

        Buff b = (Buff)obj;
        info.AddValue("Value", b.Value);
        info.AddValue("Amount", b.Amount);
        info.AddValue("Description", b.Description);
        info.AddValue("name", b.name);
        info.AddValue("Period", b.Period);
        info.AddValue("BuffType", b.BuffType);
        info.AddValue("Offensive", b.Offensive);

    }

    public System.Object SetObjectData(System.Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {

        Buff b = ScriptableObject.CreateInstance(typeof(Buff)) as Buff;
        b.Value = (float)info.GetValue("Value", typeof(float));
        b.Amount = (int)info.GetValue("Amount", typeof(int));
        b.Description = (string)info.GetValue("Description", typeof(string));
        b.name = (string)info.GetValue("name", typeof(string));
        b.Period = (Period)info.GetValue("Period", typeof(Period));
        b.BuffType = (BuffType)info.GetValue("BuffType", typeof(BuffType));
        b.Offensive = (bool)info.GetValue("Offensive", typeof(bool));
        obj = b;
        return obj;
    }
}

