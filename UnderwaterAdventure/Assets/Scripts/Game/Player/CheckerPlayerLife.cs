using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPlayerLife : MonoBehaviour
{
   [SerializeField] private LoaderPlayer _loaderPlayer;
   [SerializeField] private LoaderScene _loaderScene;
   private PlayerHealth _playerHealth;
   private void Awake() 
   {
    _loaderPlayer.OnLoadPlayer += LoadPlayer;
   }
   private void LoadPlayer(Player player)
   {
    _playerHealth =player.PlayerHealth;
    _playerHealth.OnDeath += Destroy;
   }
   private void Destroy()
   {
    StarterNewGame.StartNewGame();
    _loaderScene.OpenMenu();
   }
   private void OnDisable() 
   {
     _loaderPlayer.OnLoadPlayer -= LoadPlayer;
     _playerHealth.OnDeath -= Destroy;
   }
}
