using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private List<ItemTab> _itemTabs;
    private void Awake() 
    {
        _itemTabs.ForEach(e=> e.OnClick += SetCurrentItemTab);
    }
    private void Start() 
    {
        _itemTabs[0].TurnOn();
        _itemTabs[0].SetSizeOfButton();
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
    }
    public void SetItem(Item item)
    {
        if(item.Name != "")
        {
        _itemTabs.ForEach(e=> e.SetItem(item));
        }
    }
    private void OnDisable() 
    {
       _itemTabs.ForEach(e=> e.OnClick -= SetCurrentItemTab);
    }
}
