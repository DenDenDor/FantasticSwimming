using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : Screen
{
    private void Start()
    {
        TurnOn();
    }
    public override void SetActionToCancelButton()
    {
        CancelButton.ChangeEvent(() =>
        {
             Debug.Log("CLOSE THE APP!");
             Application.Quit();
        });
    }
}
