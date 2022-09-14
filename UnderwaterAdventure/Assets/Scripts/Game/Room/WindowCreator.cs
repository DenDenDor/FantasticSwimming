using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
   [SerializeField] private DoorCreator _doorCreator;
   [SerializeField] private List<GameWindow> _gameWindows;
    private Dictionary<(float,float), GameWindow> _dictionary = new Dictionary<(float, float), GameWindow>();
   private void Awake() 
   {
    _dictionary.Add((0,2), _gameWindows.Find(e=>e is TreasureWindow));
    _dictionary.Add((2,10),_gameWindows.Find(e=>e is BattleWindow));
    _doorCreator.OnRemoveDoor += CreateWindow;
   }
   private void CreateWindow()
   {
    int randomNumber = Random.Range(0,10);
    (float,float) couple = _dictionary.Keys.FirstOrDefault(e=>randomNumber >= e.Item1 && randomNumber < e.Item2);
    GameWindow gameWindow = Instantiate(_dictionary[couple],Vector3.zero,Quaternion.identity); 
    gameWindow.transform.SetParent(_spawnPosition);
   }
   private void OnDisable() 
   {
        _doorCreator.OnRemoveDoor -= CreateWindow;
   }
   
}
