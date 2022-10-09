using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureInformation : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Text _text;
    private Item _currentItem;
    public Item CurrentItem => _currentItem;
    public void SetItem(Item item)
    {
        _currentItem = item;
        _text.text = _currentItem.TreasureDescription;
    }
    public void TurnOn()
    {
      _canvasGroup.ChangeStateOfCanvasGroup(true);
    }
    public void TurnOff()
    {
      _canvasGroup.ChangeStateOfCanvasGroup(false);
    }
    public bool IsTurnOn() => _canvasGroup.alpha == 1;
}
