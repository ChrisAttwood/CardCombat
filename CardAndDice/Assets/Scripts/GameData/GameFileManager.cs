using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class GameFileManager {

    public static GameFile GameFile;

    public static void Save()
    {
        Save(GameFile, "Adventure");
        Load();//to create new ScriptableObjects and not alter orignals
    }

    public static void Load()
    {
        GameFile = Load<GameFile>("Adventure");
    }


    public static void Save<T>(T data,string name)
    {

        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".game");
        bf.Serialize(file, data);
        file.Close();
    }

    public static T Load<T>(string name)
    {
        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.OpenRead(Application.persistentDataPath + "/" + name + ".game");
        T data = (T)bf.Deserialize(file);
        file.Close();

        return data;
    }

    public static void Delete()
    {
        Delete("Adventure");
    }

    public static void Delete(string name)
    {

        File.Delete(Application.persistentDataPath + "/" + name + ".game");

    }


    public static bool Exists(string name)
    {
        //Debug.Log(Application.persistentDataPath);
        return File.Exists(Application.persistentDataPath + "/" + name + ".game");
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter bf = new BinaryFormatter();

        SurrogateSelector surrogateSelector = new SurrogateSelector();

        Vector3IntSerializationSurrogate vector3SS = new Vector3IntSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Vector3Int), new StreamingContext(StreamingContextStates.All), vector3SS);
        ColorSerializationSurrogate colour3SS = new ColorSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), colour3SS);
        BuffSerializationSurrogate buffSerializationSurrogate = new BuffSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Buff), new StreamingContext(StreamingContextStates.All), buffSerializationSurrogate);
        CardSerializationSurrogate cardSerializationSurrogate = new CardSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Card), new StreamingContext(StreamingContextStates.All), cardSerializationSurrogate);
        EquipmentSerializationSurrogate equipmentSerializationSurrogate = new EquipmentSerializationSurrogate();
        surrogateSelector.AddSurrogate(typeof(Equipment), new StreamingContext(StreamingContextStates.All), equipmentSerializationSurrogate);

        bf.SurrogateSelector = surrogateSelector;

        return bf;
    }
}
