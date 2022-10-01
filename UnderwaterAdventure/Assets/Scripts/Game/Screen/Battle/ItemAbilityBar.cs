using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemAbilityBar : MonoBehaviour
{
     [SerializeField] private Image _bar;
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;
    private ItemAbility _itemAbility;
    private NextMoveButton _nextMoveButton;
    private void Awake() 
    {
     _nextMoveButton = FindObjectOfType<NextMoveButton>();
     _nextMoveButton.OnStartNextMove += ChangeIcon;
    }
    private void ChangeIcon() => _bar.DivideImageBar(_itemAbility.CountForReloading, _itemAbility.CurrentCoolDown);
    private void Start() 
   {
        _text.text = _itemAbility.Description;
        _button.onClick.AddListener(UseAbility);
   }
   private void UseAbility()
   {
      _itemAbility.UseAbility();
      ChangeIcon();
   }
   public void SetItemAbility(ItemAbility itemAbility) => _itemAbility = itemAbility;
   private void OnDisable() 
   {
    _button.onClick.RemoveListener(UseAbility);
     _nextMoveButton.OnStartNextMove -= ChangeIcon;
   }
}
