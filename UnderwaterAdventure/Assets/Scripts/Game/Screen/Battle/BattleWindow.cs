using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
public class BattleWindow : GameWindow
{
    [SerializeField] private Image _panel;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Text _nameOfEnemy;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private List<Enemy> _enemies;
    private Enemy _currentEnemy;
    private WinWindow _winWindow;
    private ActiveOfMainSlots _activeOfMainSlots;
    public event Action<Enemy> OnSetEnemy;
    private void Start() 
    {
        _activeOfMainSlots = FindObjectOfType<ActiveOfMainSlots>();
        _winWindow = FindObjectOfType<WinWindow>();
        _activeOfMainSlots.TurnOff();
        _currentEnemy = _enemies[Random.Range(0,_enemies.Count)];
        _icon.color = _currentEnemy.Color;
        _nameOfEnemy.text = _currentEnemy.Name;
        _button.onClick.AddListener(OnClick);
        OnSetEnemy?.Invoke(_currentEnemy);
    }
    public void EndBattle()
    {
        _panel.gameObject.SetActive(true);
        _canvasGroup.ChangeStateOfCanvasGroup(true);
    }
    public void OnClick()
    {
        _activeOfMainSlots.TurnOn();
        _winWindow.TurnOn(_currentEnemy);
        Destroy(gameObject);
    }
    

}
