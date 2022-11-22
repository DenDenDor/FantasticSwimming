using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AbilityBeforePlayerMoveHandler : SpecialAbilityHandler<IAbilityBeforePlayerMove>
{
    [SerializeField] private BattleItemInformationCreator _battleItemInformationCreator;
   private void Awake()
   {
        _battleItemInformationCreator.OnCreate += Subscribe;
   }
    private void Subscribe() => _battleItemInformationCreator.ListOfOfItemAbilityBars.ForEach(e => e.ItemAbility.OnClick += SetItemAbility);
    private void SetItemAbility(ItemAbility itemAbility)
    {
       List<ItemAbility> listOfItemAbilities = _battleItemInformationCreator.ListOfOfItemAbilityBars.Select(e => e.ItemAbility).Where(a=>a is IAbilityBeforePlayerMove).ToList();
        
        Debug.Log(listOfItemAbilities.Count + " -1");
    }
    private void OnDisable()
    {
        _battleItemInformationCreator.OnCreate -= Subscribe;
        _battleItemInformationCreator.ListOfOfItemAbilityBars.ForEach(e => e.ItemAbility.OnClick -= SetItemAbility);
    }

}
