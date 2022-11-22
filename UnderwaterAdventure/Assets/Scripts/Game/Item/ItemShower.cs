using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ItemShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private List<ItemTab> _itemTabs;
    [SerializeField] private List<Button> _buttons;
    private Item _item;
    private void Awake() 
    {
        _itemTabs.ForEach(e=> e.OnClick += SetCurrentItemTab);
    }
    private void Start() 
    {
        _itemTabs.FirstOrDefault()?.TurnOn();
        _itemTabs.FirstOrDefault()?.SetSizeOfButton();
    }
    private void SetCurrentItemTab(ItemTab itemTab)
    {
        List<ItemTab> itemTabs = new List<ItemTab>();
        itemTabs.AddRange(_itemTabs);
        itemTabs.Remove(itemTab);
        itemTabs.ForEach(e=>e.TurnOff());
    }
    public void Disappear() => _canvasGroup.ChangeStateOfCanvasGroup(false);
    public void Appear()
    {
       _canvasGroup.ChangeStateOfCanvasGroup(true);
       _buttons.ForEach(e=>e.gameObject.SetActive(false));
       for (int i = 0; i < _item.ItemAbilities.Count; i++)
       {
        _buttons[i].gameObject.SetActive(true);
       }
    }
    public void SetItem(Item item)
    {
        if(item.Name != "")
        {
        _itemTabs.ForEach(e=> e.SetItem(item));
        }
        _item = item;
    }
    private void OnDisable() 
    {
       _itemTabs.ForEach(e=> e.OnClick -= SetCurrentItemTab);
    }
}
