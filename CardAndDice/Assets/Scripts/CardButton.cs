using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    
    public void Display(Card card)
    {

        if (card != null)
        {
            transform.GetChild(2).GetComponent<Text>().text = card.Title;
            transform.GetChild(3).GetComponent<Text>().text = card.Cost.ToString();

            string description = card.Description.AddColour();
            //if (card.Buff != null)
            //{
            //    if (string.IsNullOrEmpty(description))
            //    {
            //        description = card.Buff.Description.AddColour();
            //    }
            //    else
            //    {
            //        description += "\n" + card.Buff.Description.AddColour();
            //    }
               
            //}
            foreach(Buff buff in card.Buffs)
            {
                if (!string.IsNullOrEmpty(description))
                {
                    description += "\n";
                }
                description += buff.Description.AddColour();
            }

            transform.GetChild(4).GetComponent<Text>().text = description;

            if (card.PowerRequired > 0)
            {
                transform.GetChild(5).GetComponent<Image>().color = Color.yellow;
                transform.GetChild(6).GetComponent<Text>().text = card.PowerRequired.ToString();
            }
        }
        
    }

}
