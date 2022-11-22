using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    [SerializeField] private ItemShower _itemShower;
    private List<Slot> _currentSlots = new List<Slot>();
    private Slot _slot;
    private GameExit _gameExit;
    private Item _currentItem;

    public Item CurrentItem => _currentItem;

    private void Start() 
    {
        _gameExit = FindObjectOfType<GameExit>();
        _itemShower.Disappear();
      //  _slotCreator.OnCreate += SubscribeSlots;
    }
    public void SubscribeSlot(Slot slot)
    {
        slot.OnClick += SelectSlot;
    }
    public void DissubscribeSlot(Slot slot)
    {
        slot.OnClick -= SelectSlot;
    }
    public void Disactive()=> _itemShower.Disappear();
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
        if (_gameExit == null)
        {
          _gameExit = FindObjectOfType<GameExit>();
        }
        _gameExit.SetCurrentAction(_itemShower.Disappear);
        _itemShower.SetItem(item);
        _itemShower.Appear();
        _currentItem = item;
    }
    private void OnDisable() 
    {
     //_slotCreator.OnCreate -= SubscribeSlots;
   // _currentSlots.ForEach(e=> e.OnClick -= SelectSlot);
    }
}
