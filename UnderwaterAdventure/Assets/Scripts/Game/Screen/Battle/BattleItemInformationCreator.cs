using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BattleItemInformationCreator : Creator<BattleItemInformation>
{
   [SerializeField] private Transform _point;
   [SerializeField] private List<BattleItemInformation> _listOfBattleItemInformation;

    public List<BattleItemInformation> ListOfBattleItemInformation { get => _listOfBattleItemInformation; private set => _listOfBattleItemInformation = value; }

    public void CreateItemInformation(Slot slot)
   {
    if(slot.Item.Name != "")
    {
     BattleItemInformation battleItemInformation = Create(_point.position);
     battleItemInformation.transform.SetParent(_point);
     battleItemInformation.Slot = slot;
     battleItemInformation.TurnOff();
     ListOfBattleItemInformation.Add(battleItemInformation);
    }
   }
   public BattleItemInformation FindCurrentItemInformationInList(Slot slot)
   {
    return ListOfBattleItemInformation.Find(e=> e.Slot == slot);
   }
}
