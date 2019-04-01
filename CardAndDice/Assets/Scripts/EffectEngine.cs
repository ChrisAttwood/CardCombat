using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEngine : MonoBehaviour
{
    public static EffectEngine instance;
    public Effect EffectPrefab;

    private void Awake()
    {
        instance = this;
    }

   
    public void Create(string text,Vector3 target,DataDisplay dataDisplay)
    {
        var effect = Instantiate(EffectPrefab, transform);

        //var pos = effect.transform.position;
        //pos.y = target.y;

        //effect.transform.position = pos;
        effect.Set(text, target, dataDisplay);
    }


}
