using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenerScreenButton : MonoBehaviour
{
   [SerializeField] private Screen _screen;
   private Screen _previusScreen;
   private GetterCurrentScreen _getterCurrentScreen;
   private void Start() 
   {
    _getterCurrentScreen = FindObjectOfType<GetterCurrentScreen>();
   }
   public void OnClick()
   {
    _screen.TurnOn();
   }
}
