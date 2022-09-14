using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 1)]
public class MenuSettingsData : ScriptableObject
{
   [SerializeField] private bool _isMusicOn;
   [SerializeField] private bool _isSoundOn;

    public bool IsMusicOn { get => _isMusicOn; set => _isMusicOn = value; }
    public bool IsSoundOn { get => _isSoundOn; set => _isSoundOn = value; }
}
