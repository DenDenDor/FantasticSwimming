using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite _questionSprite;
    [SerializeField] private Image _icon;
    private Item _item;
    private bool _isItemTaken;
    private bool _isCursorOnSlot;
    public Item Item { get => _item; set => _item = value; }
    public event Action<Slot> OnDragItem; 
    public event Action<Slot> OnClick;
    public void AddItem(Item item)
    {
        SetCurrentItem(item,item.Sprite);
    }

    public Sprite ReturnItemSprite()
    {
        return Item == null ? _questionSprite : Item.Sprite;
    }
    public void RemoveItem()
    {
        SetCurrentItem(null,null);
    }
    private void SetCurrentItem(Item item, Sprite sprite)
    {
        Item = item;
        Action OnSetSpite = sprite != null ? (Action) SetSprite : (Action) TurnOffSprite;
        OnSetSpite.Invoke();
    }
    private void SetSprite()
    {
        if (_icon.isActiveAndEnabled == false)
        {
        _icon.gameObject.SetActive(true);
        }
        _icon.sprite = Item.Sprite;
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
        if (_isItemTaken == false && _item.Sprite != null)
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
