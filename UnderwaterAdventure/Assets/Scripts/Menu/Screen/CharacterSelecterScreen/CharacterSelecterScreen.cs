using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelecterScreen : Screen
{
    [SerializeField] private Text _text;
    [SerializeField] private List<ClickableChracter> _clickableChracters;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private int _countForClicks = 2;
    [SerializeField] private ContinieGameButton _continieGameButton;
    private ClickableChracter _currentClickableChracter;
    private string _startDescription;
    private void Awake() 
    {
        _startDescription = _text.text;
      _clickableChracters.ForEach(e=>e.OnClickCharacter += Click);  
    }
    private void Click(ClickableChracter clickableChracter)
    {
        if (_currentClickableChracter != null)
        {
            if(_currentClickableChracter != clickableChracter)
            {
            _currentClickableChracter.CountOfClicks = 0;
            }
            else if(_countForClicks <= _currentClickableChracter.CountOfClicks)
            {
                _currentClickableChracter.SaveSelectedCharacter();
            }
        }
        _text.text = clickableChracter.Description;
        _currentClickableChracter = clickableChracter;
    }
    public override void SetActionToCancelButton()
    {
        _text.text = _startDescription;
        CancelButton.ChangeEvent(() => _menuScreen.TurnOn());
        StarterNewGame.StartNewGame();
        _continieGameButton.gameObject.SetActive(false);
    }
    private void OnDisable() 
    {
           _clickableChracters.ForEach(e=>e.OnClickCharacter -= Click);  
    }
}
