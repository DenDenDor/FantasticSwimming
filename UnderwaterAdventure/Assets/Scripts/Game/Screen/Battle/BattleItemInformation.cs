using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleItemInformation : MonoBehaviour
{
   [SerializeField] private ItemAbilityBar _itemAbilityBar;
   [SerializeField] private CanvasGroup _canvasGroup;
   private List<ItemAbilityBar> _listOfItemAbilityBars = new List<ItemAbilityBar>();
   private Slot _slot;
   public Slot Slot { get => _slot; set => _slot = value; }
    public List<ItemAbilityBar> ListOfItemAbilityBars { get => _listOfItemAbilityBars; private set => _listOfItemAbilityBars = value; }

    public event Action<List<ItemAbilityBar>> OnCreate;
    private void Start() 
   {
     foreach (var item in Slot.Item.ItemAbilities)
     {
        ItemAbilityBar itemAbilityBar = Instantiate(_itemAbilityBar,transform.position,Quaternion.identity);
        itemAbilityBar.SetItemAbility(item);
        itemAbilityBar.transform.SetParent(transform);
        ListOfItemAbilityBars.Add(itemAbilityBar);
     }
      OnCreate.Invoke(ListOfItemAbilityBars);
    }
    public void TurnOn() => _canvasGroup.ChangeStateOfCanvasGroup(true);
   public void TurnOff() => _canvasGroup.ChangeStateOfCanvasGroup(false);
}
