using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureWindow : GameWindow
{
    [SerializeField] private List<Item> _items = new List<Item>();
    private Item _currentItem;
    private SlotCollector _slotCollector;
    private void Awake() 
    {
      _slotCollector = FindObjectOfType<SlotCollector>();
      _currentItem = _items[Random.Range(0,_items.Count)];
      _slotCollector.SlotCreator.CreateTreasureSlot(_currentItem);
      ItemInformation itemInformation = FindObjectOfType<ItemInformation>();
      itemInformation.SetItem(_currentItem);
    }
    public void Close()
    {
        DoorCreator doorCreator = FindObjectOfType<DoorCreator>();
        doorCreator.OpenAllDoors();
        Destroy(gameObject);
    }
    private void OnDisable() 
    {
        _slotCollector.SlotCreator.DestroyTreasureSlot();
    }
}
