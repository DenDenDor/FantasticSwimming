using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CancelButton : MonoBehaviour
{
    
    public event UnityAction OnClickCancelButton;
    public void ChangeEvent(UnityAction action)
    {
        OnClickCancelButton = action;
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickCancelButton?.Invoke();
        }
    }
}
