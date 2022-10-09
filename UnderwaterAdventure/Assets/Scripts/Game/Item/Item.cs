using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
  [SerializeField] private Sprite _sprite;
  [SerializeField] private string _name;
  [SerializeField] private string[] _descriptions;
  [SerializeField] private string _treasureDescription;
  [SerializeField] private List< ItemAbility> _itemAbilities;
   public Sprite Sprite { get => _sprite; private set => _sprite = value; }
   public string Name { get => _name; private set => _name = value; }
  public string[] Descriptions { get => _descriptions; set => _descriptions = value; }
  public string TreasureDescription { get => _treasureDescription; set => _treasureDescription = value; }
  public List<ItemAbility> ItemAbilities { get => _itemAbilities; set => _itemAbilities = value; }
}
