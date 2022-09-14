using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private MenuSettingsData _menuSettingsData;
    private bool _isOk;
    private void Update() 
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        _isOk =! _isOk;
        _menuSettingsData.IsMusicOn = _isOk;
        _menuSettingsData.IsSoundOn =! _isOk;
      } 
    }
}
