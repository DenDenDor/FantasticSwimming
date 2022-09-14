using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class ClickableChracter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _description;
    [SerializeField] private Player _player;
    private int _countOfClicks = 0;
    private LoaderScene _loaderScene;

    public int CountOfClicks { get => _countOfClicks; set => _countOfClicks = value; }
    public string Description { get => _description; set => _description = value; }

    public event Action<ClickableChracter> OnClickCharacter;
    private void Start() 
    {
        _loaderScene = FindObjectOfType<LoaderScene>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CountOfClicks++;
        OnClickCharacter?.Invoke(this);
    }
    public void SaveSelectedCharacter()
    {
        Saver<SavableSelectedCharacter>.Save(new SavableSelectedCharacter(_player.PlayerInformation.Name));
        _loaderScene.OpenGame();
    }
}
