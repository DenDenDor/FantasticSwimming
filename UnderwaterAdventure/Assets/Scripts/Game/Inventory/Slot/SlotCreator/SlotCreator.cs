using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class SlotCreator : Creator<Slot> 
{
   [SerializeField] private int _countOfSlots = 8;
   [SerializeField] private int _countOfFilledSlots = 2;
   [SerializeField] private List<Item> _items;
   [SerializeField] private Transform _slotPosition;
   [SerializeField] private Transform _additionalPosition;
   private Slot _treasureSlot;
   private List<Slot> _slots = new List<Slot>();
   public List<Slot> Slots => _slots;
   public List<Item> Items => _items;
   public Action<List<Slot>> OnCreate;
   public event Action OnSetStartSlots;
   private void Start() 
   {
        SavableInterface savableInterface = Loader<SavableInterface>.Load(new SavableInterface());
        List<Item> foundItems = new List<Item>();
        Action OnCheckNullableOfSavableInterface = savableInterface == null ? (Action) CreateStartSlots : (Action)TryCreateSavableSlots;
        OnCheckNullableOfSavableInterface.Invoke();
        void TryCreateSavableSlots()
        {
            Action OnTryCreate = savableInterface.NamesOfItems.Count == 0 ? (Action) CreateStartSlots : (Action) CreateSavableSlots;
            OnTryCreate.Invoke();
        }
        void CreateSavableSlots()
        {
            savableInterface.NamesOfItems.ForEach(e=> foundItems.Add(_items.Find(a=>e == a.Name)));
            foundItems.ForEach(e=> Create(_slotPosition,e));
        }
        OnCreate?.Invoke(Slots);
    }
    private void CreateStartSlots()
    {
            List<Item> allLeftItems = _items.FindAll(e=>e.Name != "");
            for (int i = 0; i < _countOfSlots; i++)
            {
                Item currentItem = _countOfFilledSlots <= i ? _items.Find(e=>e.Name == "") : allLeftItems.GetRandomElementOfList();
                 Create(_slotPosition,currentItem);
                 if (allLeftItems.Count > 0 && _countOfSlots >= i)
                 {
                    allLeftItems.Remove(currentItem);
                 }
            }
            OnSetStartSlots?.Invoke();            
    }
    public Slot Create(Transform point, Item item)
    {
        Slot slot = Create(point.position);
        slot.AddItem(item);
        slot.transform.SetParent(point);
        Slots.Add(slot);
        return slot;
    }
    public void RemoveSlot(Slot slot) 
    {
         Slots.Remove(slot);
         OnCreate?.Invoke(Slots);
    }
}
