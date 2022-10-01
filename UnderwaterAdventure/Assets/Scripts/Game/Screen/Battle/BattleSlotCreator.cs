using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSlotCreator : Creator<Slot>
{
   [SerializeField] private Transform _point;
   [SerializeField] private BattleItemInformationCreator _battleItemInformationCreator;
   private SlotCreator _slotCreator;
   private List<Slot> _additionalSlots = new List<Slot>();
   private Slot _previousSlot;
   private void Start() 
   {
    _slotCreator = FindObjectOfType<SlotCreator>();
    SavableInterface savableInterface = Loader<SavableInterface>.Load(new SavableInterface());
    foreach (var item in savableInterface.NamesOfItems)
    {
       Slot slot =  Create(_point.position);
       slot.AddItem(_slotCreator.Items.Find(e=>e.Name == item)); 
       _battleItemInformationCreator.CreateItemInformation(slot);
       slot.transform.SetParent(_point);
       slot.CanDrag = false;
       if(slot.Item.Name != "")
       {
       slot.OnClick += ClickOnSlot;
       }
       _additionalSlots.Add(slot);
    }
    ClickOnSlot(_additionalSlots.FirstOrDefault(e=>e.Item.Name != ""));    
   }
   public void IncreaseMovesOfSlots()
   {
     _additionalSlots.Select(e=>e.Item).Select(a=>a.ItemAbilities).ToList().ForEach(e=>e.ForEach(a=>a.IncreaseCoolDown()));
   }
   private void ClickOnSlot(Slot slot)
   {
      if (_previousSlot != null)
      {
       _battleItemInformationCreator.FindCurrentItemInformationInList(_previousSlot).TurnOff();
      }
     _battleItemInformationCreator.FindCurrentItemInformationInList(slot).TurnOn();
      _previousSlot= slot;
   }
   private void OnDisable() 
   {
      _additionalSlots.Where(e=>e.Item.Name != "").ToList().ForEach(e=>e.OnClick -= ClickOnSlot);
   }
}
