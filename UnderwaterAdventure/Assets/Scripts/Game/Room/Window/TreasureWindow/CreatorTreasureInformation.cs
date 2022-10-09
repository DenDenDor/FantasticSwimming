using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatorTreasureInformation : MonoBehaviour
{
    [SerializeField] private TreasureSlotsHandler _treasureSlotsHandler;
    [SerializeField] private TreasureInformation _treasureInformation;
    private List<TreasureInformation> _listOfTreasureInformation = new List<TreasureInformation>();
    [SerializeField] private Transform _point;
    private void Awake() 
    {
        _treasureSlotsHandler.OnClickOnSlot += SelectSlot;
    }
    public void OpenTreasureInformation(Item item)
    {
      _listOfTreasureInformation.Find(e=>e.CurrentItem == item).TurnOn();  
    }
    private void SelectSlot(Slot slot)
    {
        Debug.Log("HIHI");
        if(slot.Item.Name != "")
        {
      Debug.Log(slot.Item.Name);
        _listOfTreasureInformation.FirstOrDefault(e=>e.IsTurnOn())?.TurnOff();
         OpenTreasureInformation(slot.Item);
        }
    }
    public void CreateTreasureInformation(Item item)
    {
        TreasureInformation treasureInformation = Instantiate(_treasureInformation,_point.position,Quaternion.identity);
        _listOfTreasureInformation.Add(treasureInformation);
        treasureInformation.SetItem(item);
        treasureInformation.transform.SetParent(_point);
    }
    private void OnDisable() 
    {
       _treasureSlotsHandler.OnClickOnSlot -= SelectSlot;
    }
}
