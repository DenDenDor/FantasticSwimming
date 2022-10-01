using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleItemInformation : MonoBehaviour
{
   [SerializeField] private ItemAbilityBar _itemAbilityBar;
   [SerializeField] private CanvasGroup _canvasGroup;
   private Slot _slot;
   public Slot Slot { get => _slot; set => _slot = value; }
   private void Start() 
   {
     foreach (var item in Slot.Item.ItemAbilities)
     {
        ItemAbilityBar itemAbilityBar = Instantiate(_itemAbilityBar,transform.position,Quaternion.identity);
        itemAbilityBar.SetItemAbility(item);
        itemAbilityBar.transform.SetParent(transform);
     }
   } 
   public void TurnOn() => _canvasGroup.ChangeStateOfCanvasGroup(true);
   public void TurnOff() => _canvasGroup.ChangeStateOfCanvasGroup(false);
}
