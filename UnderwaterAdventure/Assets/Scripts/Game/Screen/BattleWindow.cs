using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleWindow : GameWindow
{
    [SerializeField] private Text _nameOfEnemy;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private List<Enemy> _enemies;
    private Enemy _currentEnemy;
    private WinWindow _winWindow;
    private void Start() 
    {
        _currentEnemy = _enemies[Random.Range(0,_enemies.Count)];
        _icon.color = _currentEnemy.Color;
        _nameOfEnemy.text = _currentEnemy.Name;
        _winWindow = FindObjectOfType<WinWindow>();
        _button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        _winWindow.TurnOn(_currentEnemy);
        Destroy(gameObject);
    }

}
