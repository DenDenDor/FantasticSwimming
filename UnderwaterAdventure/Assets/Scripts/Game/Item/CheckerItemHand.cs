using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerItemHand : MonoBehaviour
{
    [SerializeField] private ItemHand _itemHand;
    [SerializeField] private SlotMouseButtonHandler _slotMouseButtonHandler;
    private void Start() 
    {
        _slotMouseButtonHandler.OnGetLeftMouseButtonUp += _itemHand.SetSlots;
        _slotMouseButtonHandler.OnGetRightMouseButtonDown += _itemHand.Disappear;
    }
    private void OnDisable() 
    {
          _slotMouseButtonHandler.OnGetLeftMouseButtonUp -= _itemHand.SetSlots;
          _slotMouseButtonHandler.OnGetRightMouseButtonDown -= _itemHand.Disappear;
    }
}
