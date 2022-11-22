using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class BattleItemInformationCreator : Creator<BattleItemInformation>
{
   [SerializeField] private Transform _point;
   [SerializeField] private List<BattleItemInformation> _listOfBattleItemInformation;
    private List<ItemAbilityBar> _listOfOfItemAbilityBars = new List<ItemAbilityBar>();
    public List<BattleItemInformation> ListOfBattleItemInformation { get => _listOfBattleItemInformation; private set => _listOfBattleItemInformation = value; }
    public List<ItemAbilityBar> ListOfOfItemAbilityBars { get => _listOfOfItemAbilityBars; private set => _listOfOfItemAbilityBars = value; }
    public event Action OnCreate;
    public void CreateItemInformation(Slot slot)
   {
    if(slot.Item.Name != "")
    {
     BattleItemInformation battleItemInformation = Create(_point.position);
     battleItemInformation.transform.SetParent(_point);
     battleItemInformation.Slot = slot;
     battleItemInformation.TurnOff();
     battleItemInformation.OnCreate += AddToListOfItemAbilityBars;
     ListOfBattleItemInformation.Add(battleItemInformation);
    }
   }
    private void AddToListOfItemAbilityBars(List<ItemAbilityBar> itemAbilityBars)
    {
        _listOfOfItemAbilityBars.AddRange(itemAbilityBars);
        int maxCountOfAbilities = ListOfBattleItemInformation.SelectMany(e => e.ListOfItemAbilityBars).ToList().Count;
        if (_listOfOfItemAbilityBars.Count == maxCountOfAbilities)
        {
            OnCreate?.Invoke();
        }
    }
   public BattleItemInformation FindCurrentItemInformationInList(Slot slot)
   {
    return ListOfBattleItemInformation.Find(e=> e.Slot == slot);
   }
   public void OnDisable()
   {
        ListOfBattleItemInformation.ForEach(e => e.OnCreate -= AddToListOfItemAbilityBars);
   }
}
