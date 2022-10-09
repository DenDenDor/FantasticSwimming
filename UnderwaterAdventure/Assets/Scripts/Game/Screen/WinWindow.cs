using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class WinWindow : MonoBehaviour
{
   [Range(0.05f,1f)] [SerializeField] private float _chanceOfAppearingTreasure;
   [SerializeField] private Button _button;
   [SerializeField] private Text _text;
   [SerializeField] private CanvasGroup _canvasGroup;
   [SerializeField] private TreasureWindow _treasureWindow;
   private Enemy _currentEnemy;
   private Action OnTurnOff;
   public void TurnOn(Enemy enemy,Action OnAction)
   {
    _currentEnemy = enemy;
    OnTurnOff = OnAction;
    _canvasGroup.ChangeStateOfCanvasGroup(true);
    TryTurnOnTreasureWindow();
    ShowInterface();
   }
   private void TryTurnOnTreasureWindow()
   {
    int randomRange = Random.Range(0,1);
    Action OnAction = randomRange < _chanceOfAppearingTreasure ? (Action) TurnOnTreasureWindow: (Action) TurnOnButton;
    OnAction.Invoke();
    void TurnOnTreasureWindow()
    {
       _treasureWindow.gameObject.SetActive(true);
       _treasureWindow.OnClose += Destroy;
    }
    void TurnOnButton() => _button.gameObject.SetActive(true);
    
   }
   private void Destroy() => Destroy(gameObject);
   private void ShowInterface()
   {
    _text.text = $"{_currentEnemy.Name} повержен";
   }
   public void TurnOff()
   {
     _canvasGroup.ChangeStateOfCanvasGroup(false);
     OnTurnOff();
   }
   private void OnDisable() 
   {
     _treasureWindow.OnClose -= Destroy;

   }
}
