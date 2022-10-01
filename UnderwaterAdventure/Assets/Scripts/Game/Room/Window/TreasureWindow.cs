using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureWindow : GameWindow
{
    private Item _currentItem;
    private SlotCreator _slotCreator;
    private bool _isOpen = true;
    private AdditionalSlotCreator _additionalSlotCreator;
    private void Awake() 
    {
       _slotCreator = FindObjectOfType<SlotCreator>();
      _additionalSlotCreator = FindObjectOfType<AdditionalSlotCreator>();
      List<Item> items = _slotCreator.Slots.Select(e=>e.Item).Where(e=>e.Name != "").ToList();
      List<Item> possibleItems = _slotCreator.Items.Where(e=>e.Name != "").Except(items).ToList();
      _currentItem = possibleItems[Random.Range(0,possibleItems.Count)];
      _additionalSlotCreator.CreateAdditionalSlot(_currentItem);
      ItemInformation itemInformation = FindObjectOfType<ItemInformation>();
      itemInformation.SetItem(_currentItem);
    }
    public void Close()
    {
        _isOpen = false;
        DoorCreator doorCreator = FindObjectOfType<DoorCreator>();
        doorCreator?.OpenAllDoors();
        Destroy(gameObject);
    }
    private void OnDisable() 
    {
        if(_isOpen)
        {
            _additionalSlotCreator.ReturnSlots();
        }
        else
        {
        _additionalSlotCreator.DestroyLastSlot();
        }
        Close();
    }
}
