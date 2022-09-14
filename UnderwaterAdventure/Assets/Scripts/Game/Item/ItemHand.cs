using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHand : MonoBehaviour
{
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private Image _icon;
   [SerializeField] private SlotCollector _slotCollector;
   private bool _canMove;
   private void Start() 
   {
    _slotCollector.OnChoose += Appear;
   }
   public void SetSlots()
   {
      _slotCollector.Slots.ForEach(e=>e.TryPuttingItem());
       _slotCollector.RemoveItem();
       Disappear();

   }
   public void Disappear()
   {
     ChangeState(false,null);
   }
   private void Appear()
   {
      if(_slotCollector.CurrentSlot.Item.Sprite != null)
      {
       ChangeState(true,_slotCollector.CurrentSlot.ReturnItemSprite());
      }
   }
   private void ChangeState(bool canMove,Sprite sprite)
   {
    _canMove = canMove;
    _icon.sprite = sprite;
    _canvasGroup.alpha = canMove ? 1 : 0;
   }
   private void Update() 
   {
    if(_canMove)
    {
     MoveIcon();
    }
   }
   private void MoveIcon()
   {
      _icon.transform.position = Input.mousePosition;
   }
   private void OnDisable() 
   {
        _slotCollector.OnChoose -= Appear;
   }
}
