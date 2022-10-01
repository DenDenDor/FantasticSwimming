using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
   [SerializeField] private string _name;
   [SerializeField] private int _health = 15;
   [SerializeField] private int _maxHealth = 15;
   [SerializeField] private Color _color;
   [SerializeField] private EnemyAttack _enemyAttack;
    public string Name { get => _name; private set => _name = value; }
    public Color Color { get => _color; private set => _color = value; }
    public int Health { get => _health; set => _health = value; }
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
    public EnemyAttack EnemyAttack { get => _enemyAttack; set => _enemyAttack = value; }
}
