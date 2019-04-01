using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameFile {

    public int Seed { get; private set; }

   
    public int X;
    public int Y;

    public List<Equipment> Equipment;
    public List<Equipment> Opponent;


    public Equipment[] Loot;


    public GameFile()
    {
        Seed = Random.Range(0, 9999);

    }

   


}
