using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TreasureWindow : GameWindow
{
    private Item _currentItem;
    private bool _isOpen = true;
    private ActiveOfMainSlots _activeOfMainSlots;
    private AdditionalSlotCreator _additionalSlotCreator;
    private ItemWindowCreator _itemWindowCreator;
    public Item CurrentItem { get => _currentItem; private set => _currentItem = value; }
    public AdditionalSlotCreator AdditionalSlotCreator => _additionalSlotCreator;
    public event Action OnClose;
    private void Awake() 
    {
      _activeOfMainSlots = FindObjectOfType<ActiveOfMainSlots>();
       _activeOfMainSlots.TurnOff();
      _additionalSlotCreator = FindAdditionalSlotCreatorOnScene<TreasureWindow>();
      
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
        _activeOfMainSlots.TurnOn();
        OnClose?.Invoke();
        Close();
    }
}
