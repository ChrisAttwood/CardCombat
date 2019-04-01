using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplay : MonoBehaviour
{

    Text Text;
    int Current;
    public string Format;

   // string Stored;
    Queue<string> Stored;

    private void Awake()
    {
        Stored = new Queue<string>();
        Text = GetComponent<Text>();
        Text.text = string.Format(Format, Current);
    }

    
    public void Set(int amount)
    {
        int diff = amount - Current;

        if (diff != 0)
        {
            EffectEngine.instance.Create(string.Format(Format, diff),transform.position,this);
            Stored.Enqueue(string.Format(Format, amount));
        }

        
        Current = amount;
    } 

    public void Refresh()
    {
        Text.text = Stored.Dequeue();
    }

}
