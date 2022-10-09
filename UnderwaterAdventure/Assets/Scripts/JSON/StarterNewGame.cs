using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterNewGame : MonoBehaviour
{
    public static void StartNewGame()
    {
        Saver<SavableSelectedCharacter>.Save(new SavableSelectedCharacter(""));
        Saver<SavableInterface>.Save(new SavableInterface(new List<string>()));
        Saver<SavablePassedDoors>.Save(new SavablePassedDoors(new List<string>()));
        Saver<SavableHealth>.Save(new SavableHealth());
    }
}
