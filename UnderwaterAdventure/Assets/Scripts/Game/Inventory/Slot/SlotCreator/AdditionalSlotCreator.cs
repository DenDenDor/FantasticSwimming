using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdditionalSlotCreator : Creator<Slot>
{
  [SerializeField] private SlotCreator _slotCreator;
  [SerializeField] private Transform _slotPoint;
  [SerializeField] private GameWindow _gameWindow;
  private List<Item> _currentItems = new List<Item>(); 
  private Slot _slot;
  private List<Slot> _currentSlots = new List<Slot>();
  public List<Slot> CurrentSlots => _currentSlots;
  public GameWindow GameWindow => _gameWindow;
  public IEnumerable<Slot> CreateNewSlots(List<string> namesOfItems, Action<Slot> OnClick)
  {
    foreach (var slot in RecreateMainSlots(namesOfItems))
    {
       SubscribeSlot(slot, OnClick);
       yield return slot;
    }
  }
  public void SubscribeSlot(Slot slot,Action<Slot> OnClick)
  {
    if(slot.Item.Name != "")
    {
    slot.OnClick += OnClick;
    }
  }
  public IEnumerable<Slot> RecreateMainSlots(List<string> namesOfItems)
  {
    foreach (var item in namesOfItems)
    {
    yield return CreateSlot(_slotCreator.Items.Find(e=>e.Name == item), _slotPoint);
    }
  }
  public Slot CreateSlot(Item item, Transform point)
  {
    Slot slot =  Create(point.position);
    slot.AddItem(item); 
    _currentSlots.Add(slot);
    slot.transform.SetParent(point);
    slot.CanDrag = false;
    return slot;
  }
  public void DestroyCreatedSlots()
  {
    List<Slot> slots = new List<Slot>();
    slots.AddRange(_currentSlots);
    for (int i = 0; i < slots.Count; i++)
    {
      RemoveSlot(slots[i]);
    }
    _currentSlots.Clear();
  }
  private void RemoveSlot(Slot slot)
  {
    _slotCreator.RemoveSlot(slot);
    Destroy(slot.gameObject);
  }
}
