using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private ItemShower _itemShower;
    private List<Slot> _currentSlots = new List<Slot>();
    private Slot _slot;
    private GameExit _gameExit;
    private void Start() 
    {
        _gameExit = FindObjectOfType<GameExit>();
        _slotCreator.OnCreate += SubscribeSlots;
    }
    private void SubscribeSlots(List<Slot> slots)
    {
        _currentSlots = slots;
        _currentSlots.ForEach(e=> e.OnClick += SelectSlot);
    }
    private void SelectSlot(Slot slot)
    {
        Debug.Log($"{slot} + CLICK!");
        if(slot.Item.Name != "")
        {
        _slot = slot;
        SetItem(_slot.Item);
        }
    }
    public void SetItem(Item item)
    {
        _gameExit.SetCurrentAction(_itemShower.Disappear);
        _itemShower.Appear();
        _itemShower.SetItem(item);
    }
    private void OnDisable() 
    {
     _slotCreator.OnCreate -= SubscribeSlots;
    _currentSlots.ForEach(e=> e.OnClick -= SelectSlot);
    }
}
