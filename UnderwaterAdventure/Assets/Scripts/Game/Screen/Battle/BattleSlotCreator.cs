using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSlotCreator : MonoBehaviour
{
   [SerializeField] private BattleItemInformationCreator _battleItemInformationCreator;
   [SerializeField] private BattleWindow _battleWindow;
   private List<Slot> _additionalSlots = new List<Slot>();
   private Slot _previousSlot;
   private void Awake() 
   {
    SavableInterface savableInterface = Loader<SavableInterface>.Load(new SavableInterface());
    _battleWindow.AdditionalSlotCreator.CreateNewSlots(savableInterface.NamesOfItems,ClickOnSlot).ToList().ForEach(e=>_battleItemInformationCreator.CreateItemInformation(e));
    ClickOnSlot(_battleWindow.AdditionalSlotCreator.CurrentSlots.FirstOrDefault(e=>e.Item.Name != ""));  
   }
    public void IncreaseMovesOfSlots()
   {
     _battleWindow.AdditionalSlotCreator.CurrentSlots.Select(e=>e.Item).Select(a=>a.ItemAbilities).ToList().ForEach(e=>e.ForEach(a=>a.IncreaseCoolDown()));
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
      _battleWindow.AdditionalSlotCreator.CurrentSlots.Where(e=>e.Item.Name != "").ToList().ForEach(e=>e.OnClick -= ClickOnSlot);
      
   }
}
