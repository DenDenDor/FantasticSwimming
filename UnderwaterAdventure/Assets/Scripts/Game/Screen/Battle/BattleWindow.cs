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
    [SerializeField] private WinWindow _winWindow;
    private ActiveOfMainSlots _activeOfMainSlots;
    private AdditionalSlotCreator _additionalSlotCreator;
    public AdditionalSlotCreator AdditionalSlotCreator => _additionalSlotCreator;
    public event Action<Enemy> OnSetEnemy;
    private void Awake() 
    {
        _additionalSlotCreator = FindAdditionalSlotCreatorOnScene<BattleWindow>();
    }
    private void Start() 
    {
        _activeOfMainSlots = FindObjectOfType<ActiveOfMainSlots>();
        _activeOfMainSlots.TurnOff();
        _currentEnemy = _enemies.GetRandomElementOfList();
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
        WinWindow winWindow = Instantiate(_winWindow,Vector3.zero, Quaternion.identity);
        winWindow.transform.SetParent(FindObjectOfType<DoorCreator>().DoorPosition.transform);
        winWindow.TurnOn(_currentEnemy,_activeOfMainSlots.TurnOn);
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        OnDestroy?.Invoke();
    }

}
