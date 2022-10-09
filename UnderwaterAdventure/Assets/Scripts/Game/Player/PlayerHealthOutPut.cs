using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthOutPut : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private PlayerHealth _playerHealth;
    [SerializeField] private LoaderPlayer _loaderPlayer;
    private void Awake() 
    {
        _loaderPlayer.OnLoadPlayer += LoadPlayer;
    }
    private void LoadPlayer(Player player)
    {
        _playerHealth = player.PlayerHealth;
        _playerHealth.OnChangeHealth += ShowHealth;
        ShowHealth();
    }
    public void ShowHealth()
   {
      _healthBar.DivideImageBar(_playerHealth.PlayerInformation.MaxHealth,_playerHealth.PlayerInformation.Health);
   }
   private void OnDisable() 
   {
          _loaderPlayer.OnLoadPlayer -= LoadPlayer;
         _playerHealth.OnChangeHealth -= ShowHealth;
   }
}
