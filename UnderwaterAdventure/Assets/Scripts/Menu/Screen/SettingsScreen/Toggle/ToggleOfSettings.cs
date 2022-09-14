using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class ToggleOfSettings : MonoBehaviour
{
    [SerializeField] private MenuSettingsData _menuSettings;
    [SerializeField] private MenuSettingsData _startMenuSettings;
   [SerializeField] private Toggle _toggle;

    public Toggle Toggle { get => _toggle; private set => _toggle = value; }
    public MenuSettingsData MenuSettings { get => _menuSettings; set => _menuSettings = value; }
    public MenuSettingsData StartMenuSettings { get => _startMenuSettings; set => _startMenuSettings = value; }

    public abstract void TryLoad();
    public abstract void Save();
    public void ChangeStateOfToggle(ISavable iSavable,bool isOn)
    {
        if (iSavable != null)
        {
            Toggle.isOn = isOn;
        }
    }
    public void ChangeStateOfToggle(bool isOn)
    {
        Toggle.isOn = isOn;
    }

}
