using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoScreen : Screen
{
    [SerializeField] private MenuScreen _menuScreen;
    public override void SetActionToCancelButton()
    {
        CancelButton.ChangeEvent(() => _menuScreen.TurnOn());
    }
}
