using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryPanel;
    public Text SlotText;
    public Button SlotButton;


    private void Start()
    {
        Display();
    }

    public void Display()
    {
        for (int i = InventoryPanel.transform.childCount; i > 0; i--)
        {
            Destroy(InventoryPanel.transform.GetChild(i - 1).gameObject);
        }

        foreach(Slot slot in System.Enum.GetValues(typeof(Slot)))
        {
            var title = Instantiate(SlotText, InventoryPanel.transform);
            title.text = slot.ToString();

            var btn = Instantiate(SlotButton, InventoryPanel.transform);
            var e = GameFileManager.GameFile.Equipment.FirstOrDefault(x => x.Slot == slot);
            if (e == null)
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = "empty";
                btn.GetComponent<Image>().color = Color.black;
                btn.interactable = false;
            }
            else
            {
                btn.transform.GetChild(0).GetComponent<Text>().text = e.Title;
                btn.GetComponent<Image>().sprite = e.Sprite;
                btn.interactable = true;
            }

        }

    }
}
