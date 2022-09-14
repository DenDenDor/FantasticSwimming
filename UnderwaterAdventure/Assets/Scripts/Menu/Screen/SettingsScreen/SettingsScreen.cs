using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : Screen
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private  List<ToggleOfSettings> _togglesOfSettings;
    private void Awake() 
    {
        _togglesOfSettings.ForEach(e=>e.TryLoad());
    } 
    public override void SetActionToCancelButton()
    {
        Debug.Log("SAVE");
        CancelButton.ChangeEvent(() =>
        {
            _togglesOfSettings.ForEach(e=>e.Save());
             _menuScreen.TurnOn();
         });
    }

}
