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

    public List<Door> Doors { get => _doors; private set => _doors = value; }
    public RectTransform DoorPosition=> _doorPosition;

    public event Action OnRemoveDoor;
    private void Start() 
    {
        CreateAllDoors();
    }
    private void CreateAllDoors()
    {
        SavablePassedDoors savableDoors = Loader<SavablePassedDoors>.Load(new SavablePassedDoors());
        if (savableDoors != null)
        {
            _countOfDoors -= savableDoors.NamesOfDoors.Count;
        }
        for (int i = 0; i < _countOfDoors; i++)
        {
           CreateDoor(DoorPosition);
        }
    }
    private Door CreateDoor(Transform point)
    {
        Door door = Instantiate(_door,Vector3.zero, Quaternion.identity);
        door.transform.SetParent(point);
        door.SetListener(CloseAllDoors);
        door.OnOpenDoor += RemoveDoor;
        Doors.Add(door);
        return door;
    }
    private void RemoveDoor(Door door)
    {
        door.RemoveAllListeners();
        OnRemoveDoor?.Invoke();
        Doors.Remove(door);
    }
    private void CloseAllDoors()
    {
        Doors.ForEach(e=>e.CloseDoor());
    }
    public void OpenAllDoors()
    {
          Doors.ForEach(e=>e.gameObject.SetActive(true));
    }
}
