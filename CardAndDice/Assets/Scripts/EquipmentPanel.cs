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
    public Image SpriteBack;
    public Image SpriteTop;
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
        SpriteBack.gameObject.SetActive(true);
        SpriteBack.sprite = equipment.BackSprite;
        SpriteBack.color = equipment.BackColour;

        SpriteTop.gameObject.SetActive(true);
        SpriteTop.sprite = equipment.TopSprite;
        SpriteTop.color = equipment.TopColour;

        string details = "";

        if (equipment.HealthPoints > 0)
        {
            details += string.Format("HEALTH : {0} \n", equipment.HealthPoints);
        }
        if (equipment.ActionPoints > 0)
        {
            details += string.Format("ACTIONS : {0} \n", equipment.ActionPoints);
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
        SpriteBack.sprite = null;
        SpriteBack.gameObject.SetActive(false);
        SpriteTop.sprite = null;
        SpriteTop.gameObject.SetActive(false);

        for (int i = CardDisplay.transform.childCount; i > 0; i--)
        {
            Destroy(CardDisplay.transform.GetChild(i - 1).gameObject);
        }
    }

}
