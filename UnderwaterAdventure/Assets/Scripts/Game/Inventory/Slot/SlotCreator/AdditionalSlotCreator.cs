using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalSlotCreator : MonoBehaviour
{
  [SerializeField] private SlotCreator _slotCreator;
  [SerializeField] private Transform _slotPoint;
  [SerializeField] private SaverSlots _saverSlots;
  private List<Item> _currentItems = new List<Item>(); 
  private Slot _slot;
  public void CreateAdditionalSlot(Item item)
  {
    _currentItems = _slotCreator.Slots.Select(e=>e.Item).ToList();
    _slot = _slotCreator.Create(_slotPoint,item);
    _slotCreator.OnCreate?.Invoke(_slotCreator.Slots);
  }
  public void ReturnSlots()
  {
   List<Item> items = _slotCreator.Slots.Select(e=>e.Item).Except(_currentItems).ToList();
   Debug.Log(items[0].Name);
    Slot slot = _slotCreator.Slots.Find(e=>e.Item == items[0]);
    _slotCreator.RemoveSlot(slot);
    Destroy(slot.gameObject);
  }
  public void DestroyLastSlot()
  {
    _slotCreator.RemoveSlot(_slot);
    Destroy(_slot.gameObject);
  }
}
