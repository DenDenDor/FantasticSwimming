using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSaver : MonoBehaviour
{
   [SerializeField] private DoorCreator _doorCreator;
   private int _countOfDoors;
   private void Awake() 
   {
    _doorCreator.OnRemoveDoor += AddPassedDoor;
   }
   private void AddPassedDoor()
   {
    SavablePassedDoors savablePassedDoors = Loader<SavablePassedDoors>.Load(new SavablePassedDoors());
    if (savablePassedDoors != null)
    {
        _countOfDoors = savablePassedDoors.NamesOfDoors.Count;
    }
    _countOfDoors++;
    List<string> names = new List<string>();
    for (int i = 0; i < _countOfDoors; i++)
    {
        names.Add("door");
    }
    Saver<SavablePassedDoors>.Save(new SavablePassedDoors(names));
   }

   private void OnDisable() 
   {
      _doorCreator.OnRemoveDoor -= AddPassedDoor;  
   }
}
