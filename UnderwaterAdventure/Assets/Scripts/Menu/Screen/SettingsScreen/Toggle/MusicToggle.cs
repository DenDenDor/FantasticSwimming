using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : ToggleOfSettings
{

    public override void Save()
    {
       Saver<SavableMusicSettings>.Save(new SavableMusicSettings(){IsMusicTurnOn = Toggle.isOn});
    }
    public override void TryLoad()
    {
       SavableMusicSettings savableMusicSettings = Loader<SavableMusicSettings>.Load(new SavableMusicSettings());
       ChangeStateOfToggle(savableMusicSettings,savableMusicSettings.IsMusicTurnOn);
    }
}
