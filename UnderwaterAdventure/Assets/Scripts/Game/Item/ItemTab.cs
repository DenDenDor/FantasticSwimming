using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemTab : MonoBehaviour
{
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private Text _text;
   [SerializeField] private Button _button;
   [SerializeField] private int _index;
   [SerializeField] private Vector2 _sizeOfButton = new Vector2(120,120);
   private Vector2 _startSizeOfButton;
    public event Action<ItemTab> OnClick;
   private void Awake() 
   {
    _startSizeOfButton = _button.transform.localScale;
    _button.onClick.AddListener(Click);
    TurnOff();
   }
   public void SetItem(Item item)
   {
      if (item.ItemAbilities.Count -1 < _index)
      {
         _text.text = item.ItemAbilities.Select(e=>e.FullDescription).LastOrDefault();
         return;
      }
       _text.text = item.ItemAbilities[_index].FullDescription;
   }
   private void Click() 
   {
    SetSizeOfButton();
    TurnOn();
    OnClick?.Invoke(this);
   }
   public void SetSizeOfButton() =>  _button.transform.localScale = _sizeOfButton;

   public void TurnOn() => _canvasGroup.ChangeStateOfCanvasGroup(true);
   public void TurnOff() 
   {
    if(_canvasGroup.blocksRaycasts)
    {
      _button.transform.localScale = _startSizeOfButton;
     _canvasGroup.ChangeStateOfCanvasGroup(false);
    }
   }
   private void OnDisable() 
   {
    _button.onClick.RemoveListener(Click);
   }
}
