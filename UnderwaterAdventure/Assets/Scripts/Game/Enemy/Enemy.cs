using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
   [SerializeField] private string _name;
   [SerializeField] private Color _color;

    public string Name { get => _name; private set => _name = value; }
    public Color Color { get => _color; private set => _color = value; }
}
