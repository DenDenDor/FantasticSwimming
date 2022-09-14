using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
   [SerializeField] private PlayerInformation _playerInformation;
    public PlayerInformation PlayerInformation { get => _playerInformation; set => _playerInformation = value; }
    public void SetColor()
    {
        PlayerInformation.SpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerInformation.SpriteRenderer.color = PlayerInformation.Color;
    }
}
