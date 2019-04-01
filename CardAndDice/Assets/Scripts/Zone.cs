using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Zone : ScriptableObject
{

    public string Title;

    public Sprite Sprite;


    public int Level;


    public Equipment[] Primary;
    public Equipment[] Secondary;
    public Equipment[] Head;
    public Equipment[] Body;
    public Equipment[] Legs;


    public List<Equipment> Get()
    {
        List<Equipment> equipment = new List<Equipment>();

        if (Primary.Length > 0) equipment.Add(Primary[Random.Range(0, Primary.Length)]);
        if (Secondary.Length > 0) equipment.Add(Secondary[Random.Range(0, Secondary.Length)]);
        if (Head.Length > 0) equipment.Add(Head[Random.Range(0, Head.Length)]);
        if (Body.Length > 0) equipment.Add(Body[Random.Range(0, Body.Length)]);
        if (Legs.Length > 0) equipment.Add(Legs[Random.Range(0, Legs.Length)]);



        return equipment;

    }

}

