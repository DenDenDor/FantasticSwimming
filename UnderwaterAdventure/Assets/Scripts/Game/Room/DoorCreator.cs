using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DoorCreator : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private int _countOfDoors = 10;
    [SerializeField] private RectTransform _doorPosition;
    private List<Door> _doors = new List<Door>();
    public event Action OnRemoveDoor;
    private void Start() 
    {
        CreateAllDoors();
    }
    private void CreateAllDoors()
    {
        for (int i = 0; i < _countOfDoors; i++)
        {
           CreateDoor(_doorPosition);
        }
    }
    private Door CreateDoor(Transform point)
    {
        Door door = Instantiate(_door,Vector3.zero, Quaternion.identity);
        door.transform.SetParent(point);
        door.SetListener(CloseAllDoors);
        door.OnOpenDoor += RemoveDoor;
        _doors.Add(door);
        return door;
    }
    private void RemoveDoor(Door door)
    {
        door.RemoveAllListeners();
        OnRemoveDoor?.Invoke();
        _doors.Remove(door);
    }
    private void CloseAllDoors()
    {
        _doors.ForEach(e=>e.CloseDoor());
    }
    public void OpenAllDoors()
    {
          _doors.ForEach(e=>e.gameObject.SetActive(true));
    }
}
