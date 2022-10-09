using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TreasureWindowSlotsCreator : MonoBehaviour
{
   private Slot _additionalSlot;
   [SerializeField] private TreasureWindow _treasureWindow;
   [SerializeField] private Transform _slotPoint; 
   [SerializeField] private CreatorTreasureInformation _creatorTreasureInformation;
   private SlotMouseButtonHandler _slotMouseButtonHandler;
   private SlotCreator _slotCreator;
   private AdditionalSlotCreator _additionalSlotCreator;
   public Slot AdditionalSlot => _additionalSlot;
   public AdditionalSlotCreator AdditionalSlotCreator => _additionalSlotCreator;
   private Action<Slot> OnClickSlot;
   private void Start() 
   {
    _slotCreator = FindObjectOfType<SlotCreator>();
    _slotMouseButtonHandler = FindObjectOfType<SlotMouseButtonHandler>();
    SavableInterface savableInterface = Loader<SavableInterface>.Load(new SavableInterface());
    _additionalSlotCreator = _treasureWindow.AdditionalSlotCreator;
    _additionalSlotCreator.CreateNewSlots(savableInterface.NamesOfItems,OnClickSlot).ToList().ForEach(e=>
    {
      _creatorTreasureInformation.CreateTreasureInformation(e.Item);
    });
    List<Item> items = _slotCreator.Slots.Select(e=>e.Item).Where(e=>e.Name != "").ToList();
    List<Item> possibleItems = _slotCreator.Items.Where(e=>e.Name != "").Except(items).ToList();
    Item item = possibleItems.GetRandomElementOfList();
    CreateAdditionalSlot(item);
   }  
   public void SetOnClickSlotAction(Action<Slot> action) => OnClickSlot = action;
   public void CreateAdditionalSlot(Item item)
  {
    _additionalSlot = _additionalSlotCreator.CreateSlot(item,_slotPoint);
    _additionalSlotCreator.SubscribeSlot(_additionalSlot,OnClickSlot);
    _creatorTreasureInformation.CreateTreasureInformation(item);
    _creatorTreasureInformation.OpenTreasureInformation(item);
  }
   private void OnDisable() 
   {
      _treasureWindow.AdditionalSlotCreator.CurrentSlots.Remove(_treasureWindow.AdditionalSlotCreator.CurrentSlots.LastOrDefault());
      for (int i = 0; i < _treasureWindow.AdditionalSlotCreator.CurrentSlots.Count; i++)
      {
         _slotCreator.Slots[i].AddItem(_treasureWindow.AdditionalSlotCreator.CurrentSlots[i].Item);
      }
      //_slotCreator.Slots.Remove(_slotCreator.Slots.Where(e=>e.Item ==_additionalSlot.Item).LastOrDefault());
      SaverSlots saverSlots =  FindObjectOfType<SaverSlots>();
      saverSlots?.Save();
      _treasureWindow.AdditionalSlotCreator.CurrentSlots.Where(e=>e.Item.Name != "").ToList().ForEach(e=>e.OnClick -= OnClickSlot);
      for (int i = 0; i < _treasureWindow.AdditionalSlotCreator.CurrentSlots.Count; i++)
      {
        Destroy(_treasureWindow.AdditionalSlotCreator.CurrentSlots[i].gameObject);
      }
      _treasureWindow.AdditionalSlotCreator.CurrentSlots.Clear();
   }
}
