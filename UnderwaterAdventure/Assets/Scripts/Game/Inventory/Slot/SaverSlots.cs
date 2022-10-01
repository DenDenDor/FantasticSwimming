using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SaverSlots : MonoBehaviour
{
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private SlotMouseButtonHandler _slotMouseButtonHandler;
    private void Awake() 
    {
        _slotMouseButtonHandler.OnGetLeftMouseButtonUp += Save;
        _slotCreator.OnSetStartSlots += Save;
    }
    public void Save()
    {
        List<string> namesOfItems = _slotCreator.Slots.Select(e=>e.Item).Select(e=>e.Name).ToList();
        for (int i = 0; i < namesOfItems.Count; i++)
        {
          //Debug.Log(namesOfItems[i] + " -=- " + i);
        }
        Saver<SavableInterface>.Save(new SavableInterface(namesOfItems));
    }
    private void OnDisable() 
    {
         _slotCreator.OnSetStartSlots -= Save;
         _slotMouseButtonHandler.OnGetLeftMouseButtonUp -= Save;
    }
    

}
