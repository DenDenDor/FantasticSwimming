using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContinieGameButton : MonoBehaviour
{
   [SerializeField] private LoaderScene _loaderScene;
   private void Start() 
   {
    SavableSelectedCharacter savableSelectedCharacter = Loader<SavableSelectedCharacter>.Load(new SavableSelectedCharacter());
    if (savableSelectedCharacter == null)
    {
        gameObject.SetActive(false);
    }
    string nameOfPlayer = savableSelectedCharacter.NameOfSelectedCharacter;//loader.Load(new SavableSelectedCharacter()).NameOfSelectedCharacter;
    if (nameOfPlayer == "")
    {
        gameObject.SetActive(false);
    }
   }
   
   public void OnClick()
   {
         _loaderScene.OpenGame();
   }
}
