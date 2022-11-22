using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DisplayerPlayerProtection", menuName = "ScriptableObjects/DisplayerPlayerProtection", order = 1)]
public abstract class DisplayerPlayerProtection : ScriptableObject
{
    private protected PlayerInformation _playerInformation;
    private protected Image _bar;
    public abstract void DisplayProtection();
    public void SetPlayerInformation(PlayerInformation playerInformation, Image bar)
    {
        _playerInformation = playerInformation;
        _bar = bar;
    }
}
