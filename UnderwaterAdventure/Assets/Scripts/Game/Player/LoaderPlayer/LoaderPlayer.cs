using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LoaderPlayer : MonoBehaviour
{
   [SerializeField] private PlayerCreator _playerCreator;
   [SerializeField] private List<Player> _players;
   private Player _currentPlayer;
   public event Action<Player> OnLoadPlayer;
   private void Start() 
   {
     string nameOfPlayer = Loader<SavableSelectedCharacter>.Load(new SavableSelectedCharacter()).NameOfSelectedCharacter;//loader.Load(new SavableSelectedCharacter()).NameOfSelectedCharacter;
     _currentPlayer = _playerCreator.Create(Vector3.zero);
     _currentPlayer.PlayerInformation = _players.Find(e=> e.PlayerInformation.Name == nameOfPlayer).PlayerInformation;
     _currentPlayer.SetColor();
     OnLoadPlayer?.Invoke(_currentPlayer);
   }
}
