using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DisplayerPlayerArmorPoints", menuName = "ScriptableObjects/DisplayerPlayerProtection/DisplayerPlayerArmorPoints", order = 1)]
public class DisplayerPlayerArmorPoints : DisplayerPlayerProtection
{
    public override void DisplayProtection()
    {
        _bar.DivideImageBar(_playerInformation.MaxArmorPoints, _playerInformation.ArmorPoints);
    }
}
