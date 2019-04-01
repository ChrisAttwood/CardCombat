using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{

    public static EquipmentPanel instance;

    public GameObject CardDisplay;
    public Button CardButton;
    public Text Title;
    public Image Sprite;
    public Text Details;

    private void Awake()
    {
        instance = this;
        Clear();
    }

    
    public void Display(Equipment equipment)
    {
        Clear();

        foreach (Card card in equipment.Cards)
        {
            if (card != null)
            {
                var btn = Instantiate(CardButton, CardDisplay.transform);

                btn.GetComponent<CardButton>().Display(card);
                btn.interactable = true;
            }
            

        }

        Title.text = equipment.Title;
        Sprite.gameObject.SetActive(true);
        Sprite.sprite = equipment.Sprite;

        string details = "";

        if (equipment.HealthPoints > 0)
        {
            details += string.Format("HEALTH : {0} \n", equipment.HealthPoints);
        }
        if (equipment.ActionPoints > 0)
        {
            details += string.Format("ACTION : {0} \n", equipment.ActionPoints);
        }
        if (equipment.ArmourPoints > 0)
        {
            details += string.Format("DEFENCE : {0} \n", equipment.ArmourPoints);
        }
        if (equipment.TacticPoints > 0)
        {
            details += string.Format("TATICS : {0} \n", equipment.TacticPoints);
        }

        Details.text = details.AddColour();
    }

    public void Clear()
    {
        Title.text = "";
        Details.text = "";
        Sprite.sprite = null;
        Sprite.gameObject.SetActive(false);
        for (int i = CardDisplay.transform.childCount; i > 0; i--)
        {
            Destroy(CardDisplay.transform.GetChild(i - 1).gameObject);
        }
    }

}
