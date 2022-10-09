using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindowCreator : MonoBehaviour
{
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private SlotMouseButtonHandler _slotMouseButtonHandler;
    [SerializeField] private ItemInformation _itemInformation;
    [SerializeField] private Transform _additionalSlot;
    private List<Slot> _slots = new List<Slot>();
    private List<ItemInformation> _listOfItemInformation = new List<ItemInformation>();
   private void Start() 
   {
    _slotCreator.OnCreate += SetListOfSlots;
    _slotMouseButtonHandler.OnActionBeforeRefreshingSlots += DissubscribeSlots;
    _slotMouseButtonHandler.OnGetLeftMouseButtonUp += RefreshListOfItemInformation;
   }
   private void DissubscribeSlots()
   {
    ReturnTuple().ToList().ForEach(e=> e.Item2.DissubscribeSlot(e.Item1));
   }
   private void RefreshListOfItemInformation()
   {
    ReturnTuple().ToList().ForEach(e=> e.Item2.SubscribeSlot(e.Item1));
   }
   private IEnumerable<(Slot,ItemInformation)> ReturnTuple()
   {
        foreach (var item in _slotCreator.Slots)
    {
        ItemInformation itemInformation = _listOfItemInformation.Find(e=>e.CurrentItem == item.Item);
        if (itemInformation != null)
        {
            yield return (item,itemInformation);
        }
    }
   }
   private void SetListOfSlots(List<Slot> slots)
   {
    List<Slot> slotsWithItems = slots.FindAll(e=>e.Item.Name != "");
    _slots = slots;
    slots.ForEach(e=>e.OnClick += DisactiveItemWindows);
    slotsWithItems.ForEach(e=>CreateItemInformation(e));
    RefreshListOfItemInformation();
   }
   private void DisactiveItemWindows(Slot slot)
   {
     if(slot.Item.Name != "")
     {
     ReturnTuple().Where(e=>e.Item1 != slot).ToList().ForEach(e=>e.Item2.Disactive());
     }
   }
   private void CreateItemInformation(Slot slot)
   {
    if(_listOfItemInformation.Select(e=>e.CurrentItem).Contains(slot.Item))
    {
        return;
    }
    
    ItemInformation itemInformation = Instantiate(_itemInformation, _additionalSlot.transform.position,Quaternion.identity);
    itemInformation.SetItem(slot.Item);
    _listOfItemInformation.Add(itemInformation);
    itemInformation.transform.SetParent(_additionalSlot);
    
   }
   private void OnDisable() 
   {
         _slots.ForEach(e=>e.OnClick -= DisactiveItemWindows);
        _slotCreator.OnCreate -= SetListOfSlots;
        _slotMouseButtonHandler.OnActionBeforeRefreshingSlots -= DissubscribeSlots;
        _slotMouseButtonHandler.OnGetLeftMouseButtonUp -= RefreshListOfItemInformation;
   }
}
