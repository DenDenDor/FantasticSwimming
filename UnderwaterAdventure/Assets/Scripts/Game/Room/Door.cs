using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Door : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event UnityAction<Door> OnOpenDoor;
    public void SetListener(UnityAction action)
    {
        _button.onClick.AddListener(OpenDoor);
         _button.onClick.AddListener(action);
    }
    public void RemoveAllListeners() => _button.onClick.RemoveAllListeners();
    private void OpenDoor()
    {
        OnOpenDoor?.Invoke(this);
        Destroy(gameObject);
    }
    public void CloseDoor() => gameObject.SetActive(false);
    
} 
