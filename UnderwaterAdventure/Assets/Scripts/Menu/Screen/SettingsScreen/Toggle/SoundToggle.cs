using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : ToggleOfSettings
{
    public override void Save()
    {
       // MenuSettings.IsSoundOn = Toggle.isOn;
        Saver<SavableSoundSettings>.Save(new SavableSoundSettings(){IsSoundTurnOn = Toggle.isOn});
    }

    public override void TryLoad()
    {
        
       // ChangeStateOfToggle(MenuSettings.IsSoundOn);
        SavableSoundSettings savableSoundSettings = Loader<SavableSoundSettings>.Load(new SavableSoundSettings());
        ChangeStateOfToggle(savableSoundSettings,savableSoundSettings.IsSoundTurnOn);
    }    

}
