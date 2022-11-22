using System.Net.NetworkInformation;
using System;
using UnityEngine;
[Serializable]
public class PlayerInformation 
{
    [SerializeField] private int _health = 20;
    [SerializeField] private int _armorPoints;
    [SerializeField] private int _maxArmorPoints = 0;
    [SerializeField] private int _maxHealth = 20;
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public string Name { get => _name; set => _name = value; }
    public Color Color { get => _color; set => _color = value; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
    public int Health { get => _health; set => _health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public int ArmorPoints { get => _armorPoints; set => _armorPoints = value; }
    public int MaxArmorPoints { get => _maxArmorPoints; set => _maxArmorPoints = value; }
}
