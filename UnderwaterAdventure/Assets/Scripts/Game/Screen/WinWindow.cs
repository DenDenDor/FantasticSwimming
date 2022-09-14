using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinWindow : MonoBehaviour
{
   [SerializeField] private Text _text;
   [SerializeField] private CanvasGroup _canvasGroup;
   private Enemy _currentEnemy;
   public void TurnOn(Enemy enemy)
   {
    _currentEnemy = enemy;
    ChangeCanvasGroup(true);
    ShowInterface();
   }
   private void ShowInterface()
   {
    _text.text = $"{_currentEnemy.Name} повержен";
   }
   public void TurnOff() => ChangeCanvasGroup(false);
   private void ChangeCanvasGroup(bool isTurnOn)
   {
    _canvasGroup.blocksRaycasts = isTurnOn;
    _canvasGroup.alpha = isTurnOn ? 1 : 0;
   }
}
