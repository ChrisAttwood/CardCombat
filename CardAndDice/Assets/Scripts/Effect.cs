using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    Vector3 target;
    DataDisplay dd;

    public void Set(string text,Vector3 target,DataDisplay dataDisplay)
    {
        dd = dataDisplay;
        this.target = target;
        GetComponent<Text>().text = text;
    }

    private void Update()
    {
        var d = Vector3.Distance(target, transform.position);

        if (d > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position,target,2000f /d);
        }
        else
        {
            dd.Refresh();
            Destroy(gameObject);
        }
    }

}
