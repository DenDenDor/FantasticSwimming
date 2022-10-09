using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefresherSlot : MonoBehaviour
{
    [SerializeField] private SlotCollector _slotCollector;
    private void Start() 
    {
      _slotCollector.OnRefresh +=  Refresh;
    }
    public void Refresh((Slot firstSlot, Slot secondSlot) coupleOfSlots)
    {
       Item additonalItem = coupleOfSlots.firstSlot.Item;
       coupleOfSlots.firstSlot.AddItem(coupleOfSlots.secondSlot.Item);
       coupleOfSlots.secondSlot.AddItem(additonalItem);
    }
    private void OnDisable() 
    {
       _slotCollector.OnRefresh -=  Refresh;
    }
}
