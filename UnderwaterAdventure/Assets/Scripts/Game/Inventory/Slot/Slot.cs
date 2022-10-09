using System.Linq;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite _questionSprite;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _panel;
    private Item _item;
    private bool _isItemTaken;
    private bool _isCursorOnSlot;
    public bool CanDrag { get; set; } = true;
    public Item Item { get => _item; set => _item = value; }
    public event Action<Slot> OnDragItem; 
    public event Action<Slot> OnClick;
    private void Start()
    {
      if (Item.Name != "")
      {
        _item.ItemAbilities.ToList().ForEach(e=>e.SetStartCountForReloading());
      }   
    }
    public void TurnOnLight()
    {
        _panel.gameObject.SetActive(true);
    }
    public void TurnOffLight()
    {
        _panel.gameObject.SetActive(false);
    }
    public void AddItem(Item item)
    {
        SetCurrentItem(item);
    }

    public Sprite ReturnItemSprite()
    {
        return Item == null ? _questionSprite : Item.Sprite;
    }
    public void RemoveItem()
    {
        SetCurrentItem(null);
    }
    private void SetCurrentItem(Item item)
    {
        Item = item;
        Action OnHasItem = _item != null ?  (Action)CheckSprite :  (Action)TurnOffSprite;
        OnHasItem.Invoke();
        void CheckSprite()
        {
        Action OnSetSpite = Item.Sprite != null ? (Action) SetSprite : (Action) TurnOffSprite;
        OnSetSpite.Invoke();
        }
    }
    private void SetSprite()
    {
         TurnOnSprite();
        _icon.sprite = Item.Sprite;
    }
    private void TurnOnSprite()
    {
         if (_icon.isActiveAndEnabled == false)
        {
        _icon.gameObject.SetActive(true);
        }
    }
    private void TurnOffSprite()
    {
        _icon.gameObject.SetActive(false);
    }
    public void Replace(Vector3 position)
    {
        transform.position = position;
    }
    public void TryPuttingItem()
    {
        _icon.enabled = true;
        if (_isCursorOnSlot)
        {
             OnDragItem?.Invoke(this);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLikc ==!");
        OnClick?.Invoke(this);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //OnClick?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isItemTaken == false && _item.Sprite != null && CanDrag)
        {
            _isItemTaken = true;
            OnDragItem?.Invoke(this);
            _icon.enabled = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isItemTaken = false;
        if (_isCursorOnSlot)
        {
            OnDragItem?.Invoke(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isCursorOnSlot= true;
        StopCoroutine(CoolDown());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.1f);
        _isCursorOnSlot =false;
    }
}
