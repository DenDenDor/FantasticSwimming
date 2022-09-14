using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterCurrentScreen : MonoBehaviour
{
   [SerializeField] private List<Screen> _screens;
   private Screen _currentScreen;
   public Screen CurrentScreen { get => _currentScreen; private set => _currentScreen = value; }
   private void Awake() 
   {
    _screens.ForEach(e=> e.OnTurnOn += SetCurrentScreen);
   }
   private void OnDisable() 
   {
        _screens.ForEach(e=> e.OnTurnOn -= SetCurrentScreen);
   }
   private void SetCurrentScreen(Screen screen)
   {
    CurrentScreen?.TurnOff();
    CurrentScreen = screen;
   }
}
