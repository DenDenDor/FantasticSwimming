using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TreasureSlotsHandler : MonoBehaviour
{
    [SerializeField] private TreasureWindowSlotsCreator _treasureWindowSlotsCreator;
    [SerializeField] private TreasureWindow _treasureWindow;
    private bool _canTakeItem;
    private SlotMouseButtonHandler _slotMouseButtonHandler;
    public event Action<Slot> OnClickOnSlot;
    private void Awake() 
    {
        _treasureWindowSlotsCreator.SetOnClickSlotAction(ClickOnSlot);
    }
    private void Start() 
    {
        _slotMouseButtonHandler = FindObjectOfType<SlotMouseButtonHandler>();
    }
    private void ClickOnSlot(Slot slot)
   {
    OnClickOnSlot?.Invoke(slot);
      if (_canTakeItem)
      {
          Refresh(slot);
         _canTakeItem = false;
      }
   } 
     public void TakeItem()
    {
      List<Item> items = _treasureWindowSlotsCreator.AdditionalSlotCreator.CurrentSlots.Select(e=>e.Item).ToList();
      Action OnTakeItem = items.All(e=>e.Name != "") ? (Action) SelectItem : (Action) FullOpenSlot;
      OnTakeItem.Invoke();
    } 
    private void FullOpenSlot()
    {
         Refresh(_treasureWindowSlotsCreator.AdditionalSlotCreator.CurrentSlots.FirstOrDefault(e=>e.Item.Name == ""));
        _treasureWindow.Close();
    } 
    private void SelectItem()
    {
      _canTakeItem = true;
      _treasureWindowSlotsCreator.AdditionalSlotCreator.CurrentSlots.ForEach(e=>e.TurnOnLight());
    }
    private void Refresh(Slot slot)
   {
          RefresherSlot refresherSlot = FindObjectOfType<RefresherSlot>();
          refresherSlot.Refresh((slot,_treasureWindowSlotsCreator.AdditionalSlot));
         _slotMouseButtonHandler.OnGetLeftMouseButtonUp?.Invoke();
         _treasureWindowSlotsCreator.AdditionalSlotCreator.CurrentSlots.ForEach(e=>e.TurnOffLight());
   }
}
