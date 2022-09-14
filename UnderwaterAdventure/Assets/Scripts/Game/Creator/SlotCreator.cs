using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SlotCreator : Creator<Slot> 
{
   [SerializeField] private int _countOfSlots = 8;
   [SerializeField] private List<Item> _items;
   [SerializeField] private Transform _slotPosition;
   [SerializeField] private Transform _additionalPosition;
   private Slot _treasureSlot;
   private int _countForReplacingToAdditionalPosition = 0;
   private List<Slot> _slots = new List<Slot>();
   public event Action<List<Slot>> OnCreate;
   private void Start() 
   {
        for (int i = 0; i < _countOfSlots; i++)
        {
            Create(_slotPosition,_items[UnityEngine.Random.Range(0,_items.Count)]);
            
            //Transform slotPosition = _countForReplacingToAdditionalPosition != i ? _slotPosition : _additionalPosition;
        }
        OnCreate?.Invoke(_slots);
    }
    private Slot Create(Transform point, Item item)
    {
        Slot slot = Create(point.position);
        slot.AddItem(item);
        slot.transform.SetParent(point);
        _slots.Add(slot);
        return slot;
    }
    public void CreateTreasureSlot(Item item)
    {
       _treasureSlot = Create(_additionalPosition, item);
        OnCreate?.Invoke(_slots);
    }
    public void DestroyTreasureSlot()
    {
        _slots.Remove(_treasureSlot);
        Destroy(_treasureSlot.gameObject);
        OnCreate?.Invoke(_slots);
    }
}
