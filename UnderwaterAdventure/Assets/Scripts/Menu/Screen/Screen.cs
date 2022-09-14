using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour
{
   [SerializeField] private CancelButton _cancelButton;
   [SerializeField] private CanvasGroup _canvasGroup;
    public CancelButton CancelButton { get => _cancelButton; private set => _cancelButton = value; }
    public event Action<Screen> OnTurnOn;
    private void ChangeActive(bool active)
    {
        _canvasGroup.blocksRaycasts = active;
        _canvasGroup.alpha = active ? 1 : 0;
    }
    public void TurnOn()
    {
        ChangeActive(true);
        SetActionToCancelButton();
        OnTurnOn?.Invoke(this);
    }
    public void TurnOff() =>ChangeActive(false);
    public abstract void SetActionToCancelButton();
}
