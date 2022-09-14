using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class SlotCollector : MonoBehaviour
{
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private SlotMouseButtonHandler _slotMouseButtonHandler;
    private List<Slot> _slots = new List<Slot>();
    private Slot _currentSlot;
    public Slot CurrentSlot { get => _currentSlot; private set => _currentSlot = value; }
    public List<Slot> Slots { get => _slots; private set => _slots = value; }
    public SlotCreator SlotCreator { get => _slotCreator; private set => _slotCreator = value; }

    public event Action<(Slot firstSlot, Slot secondSlot)> OnRefresh;
    public event Action OnChoose;
    private void Awake()
    {
        SlotCreator.OnCreate+=GetAllSlots; 
        _slotMouseButtonHandler.OnGetRightMouseButtonDown += RemoveItem;
    }
    public void RemoveItem() => CurrentSlot = null;
    private void GetAllSlots(List<Slot> slots)
    {
         Slots = slots;
         Slots.ForEach(e=>e.OnDragItem += ChooseSlot);
    }
    
    private void ChooseSlot(Slot slot)
    {
        if (_currentSlot != null && slot.Item.Name != _currentSlot.Item.Name)
        {
            OnRefresh?.Invoke((_currentSlot,slot));
            RemoveItem();
            return;
        }
        _currentSlot = slot;
        OnChoose?.Invoke();
    }
    private void OnDisable() 
    {
        Slots.ForEach(e=>e.OnDragItem -= ChooseSlot);
        SlotCreator.OnCreate-= GetAllSlots; 
        _slotMouseButtonHandler.OnGetRightMouseButtonDown -= RemoveItem;
    }
    
}
