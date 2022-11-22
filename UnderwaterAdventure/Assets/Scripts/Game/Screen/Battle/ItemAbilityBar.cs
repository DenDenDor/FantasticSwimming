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
    public ItemAbility ItemAbility { get => _itemAbility; private set => _itemAbility = value; }

    private void Awake() 
    {
     _nextMoveButton = FindObjectOfType<NextMoveButton>();
     _nextMoveButton.OnStartNextMove += ChangeIcon;
    }
    private void ChangeIcon() => _bar.DivideImageBar(ItemAbility.CountForReloading, ItemAbility.CurrentCoolDown);
    private void Start() 
   {
        _text.text = ItemAbility.Description;
        _button.onClick.AddListener(UseAbility);
   }
   private void UseAbility()
   {
        Debug.Log(" BOB! ");
      ItemAbility.UseAbility();
      ChangeIcon();
   }
   public void SetItemAbility(ItemAbility itemAbility) => ItemAbility = itemAbility;
   private void OnDisable() 
   {
    _button.onClick.RemoveListener(UseAbility);
     _nextMoveButton.OnStartNextMove -= ChangeIcon;
   }
}
