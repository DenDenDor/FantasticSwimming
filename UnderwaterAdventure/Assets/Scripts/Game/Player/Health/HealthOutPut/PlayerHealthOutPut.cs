using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthOutPut : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private DisplayerPlayerProtection _displayerPlayerProtection;
    private PlayerHealth _playerHealth;
    [SerializeField] private LoaderPlayer _loaderPlayer;
    public DisplayerPlayerProtection DisplayerPlayerProtection { get => _displayerPlayerProtection; private set => _displayerPlayerProtection = value; }

    private void Awake() 
    {
        _loaderPlayer.OnLoadPlayer += LoadPlayer;
    }
    private void LoadPlayer(Player player)
    {
        _playerHealth = player.PlayerHealth;
        DisplayerPlayerProtection.SetPlayerInformation(_playerHealth.PlayerInformation, _healthBar);
        _playerHealth.OnChangeHealth += ShowHealth;
        ShowHealth();
    }
    public void ShowHealth() => DisplayerPlayerProtection.DisplayProtection();
   private void OnDisable() 
   {
          _loaderPlayer.OnLoadPlayer -= LoadPlayer;
         _playerHealth.OnChangeHealth -= ShowHealth;
   }
}
