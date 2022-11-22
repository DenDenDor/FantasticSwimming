using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DisplayerPlayerHealth", menuName = "ScriptableObjects/DisplayerPlayerProtection/DisplayerPlayerHealth", order = 1)]
public class DisplayerPlayerHealth : DisplayerPlayerProtection
{
   public override void DisplayProtection()
    {
        _bar.DivideImageBar(_playerInformation.MaxHealth, _playerInformation.Health);  
    }
}
