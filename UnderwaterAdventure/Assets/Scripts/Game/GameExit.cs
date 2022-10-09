using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameExit : MonoBehaviour
{
   private event UnityAction OnPressEscape;
   private LoaderScene _loaderScene;
   private void Start() 
   {
    _loaderScene = FindObjectOfType<LoaderScene>();
   }
   public void SetCurrentAction(UnityAction OnAction)
   {
    OnPressEscape = OnAction;
   }
   private void Update() 
   {
   if (Input.GetKeyDown(KeyCode.Escape))
    {
        OnPressEscape?.Invoke();
        OnPressEscape = _loaderScene.OpenMenu;
    }
   }
}
