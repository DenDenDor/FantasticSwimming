using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInformation _playerInformation;
    private PlayerHealth _playerHealth;
    public PlayerInformation PlayerInformation { get => _playerInformation; set => _playerInformation = value; }
    public PlayerHealth PlayerHealth { get => _playerHealth; private set => _playerHealth = value; }

    public void SetColor()
    {
        PlayerInformation.SpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerInformation.SpriteRenderer.color = PlayerInformation.Color;
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerHealth.PlayerInformation = PlayerInformation;
        PlayerHealth.SetStartHealth();
    }
}
