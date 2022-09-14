using System.Net.NetworkInformation;
using System;
using UnityEngine;
[Serializable]
public class PlayerInformation 
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public string Name { get => _name; set => _name = value; }
    public Color Color { get => _color; set => _color = value; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
}
