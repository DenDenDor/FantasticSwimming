using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOfMainSlots : MonoBehaviour
{
   [SerializeField] private CanvasGroup _canvasGroup;
   public void TurnOn() => _canvasGroup.ChangeStateOfCanvasGroup(true);
   public void TurnOff() => _canvasGroup.ChangeStateOfCanvasGroup(false);
}
