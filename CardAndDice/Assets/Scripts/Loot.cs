using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loot : MonoBehaviour
{
    public GameObject LootPanel;
    public Text SlotText;
    public Button SlotButton;

    public GameObject TrainPanel;
    public GameObject CardPanel;

    public GameObject ChoicePanel;

    public Button CardButton;

    private void Awake()
    {
        TrainPanel.SetActive(false);
        ChoicePanel.SetActive(false);
    }

   
    void Start()
    {
        Display();
    }

    public void Display()
    {


        foreach (Slot slot in System.Enum.GetValues(typeof(Slot)))
        {
            var title = Instantiate(SlotText, LootPanel.transform);
            title.text = slot.ToString();

            var btn = Instantiate(SlotButton, LootPanel.transform);
            var equip = GameFileManager.GameFile.Equipment.FirstOrDefault(x => x.Slot == slot);
            if (equip == null)
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = "empty";
                btn.GetComponent<Image>().color = Color.black;
                btn.interactable = false;
            }
            else
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = equip.Title;
                btn.GetComponent<Image>().sprite = equip.Sprite;
                btn.interactable = true;
                btn.onClick.AddListener(delegate { Train(equip); });
                var ei = btn.gameObject.AddComponent<EquipmentIcon>();
                ei.Equipment = equip;
            }

            var lootBtn = Instantiate(SlotButton, LootPanel.transform);
            var loot = GameFileManager.GameFile.Loot.FirstOrDefault(x => x.Slot == slot);
            if (loot == null)
            {
                lootBtn.transform.GetChild(0).GetComponent<Text>().text = "empty";
                lootBtn.GetComponent<Image>().color = Color.black;
                lootBtn.interactable = false;
            }
            else
            {
                lootBtn.transform.GetChild(0).GetComponent<Text>().text = loot.Title;
                lootBtn.GetComponent<Image>().sprite = loot.Sprite;
                lootBtn.interactable = true;
                lootBtn.onClick.AddListener(delegate { Select(loot); });
                var ei = lootBtn.gameObject.AddComponent<EquipmentIcon>();
                ei.Equipment = loot;
            }


        }

    }

    public void Select(Equipment equipment)
    {
        var e = GameFileManager.GameFile.Equipment.FirstOrDefault(x => x.Slot == equipment.Slot);
        if (e != null)
        {
            GameFileManager.GameFile.Equipment.Remove(e);
        }

        GameFileManager.GameFile.Equipment.Add(equipment);
        GameFileManager.Save();
        SceneManager.LoadScene("Map");
    }

   
    public void Train(Equipment equipment)
    {
        TrainPanel.SetActive(true);

        foreach (Card card in equipment.Cards)
        {
            if (card != null)
            {
                var btn = Instantiate(CardButton, CardPanel.transform);
                btn.GetComponent<CardButton>().Display(card);
                btn.onClick.AddListener(delegate { Choice(equipment, card); });
            }
         
        }

    }

    public void Choice(Equipment equipment,Card card)
    {
        SelectedEquipment = equipment;
        SelectedCard = card;
        ChoicePanel.SetActive(true);
        var btn = Instantiate(CardButton, ChoicePanel.transform);
        btn.GetComponent<CardButton>().Display(card);

    }

    Equipment SelectedEquipment;
    Card SelectedCard;

    public void RemoveCard()
    {
        SelectedEquipment.Cards.Remove(SelectedCard);
        GameFileManager.Save();
        SceneManager.LoadScene("Map");
    }



    public void DuplicateCard()
    {
        SelectedEquipment.Cards.Add(SelectedCard.GetCopy());
        GameFileManager.Save();
        SceneManager.LoadScene("Map");
    }
}
