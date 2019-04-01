using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Equipment Equipment { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EquipmentPanel.instance.Display(Equipment);
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EquipmentPanel.instance.Clear();
      
    }

   
}
