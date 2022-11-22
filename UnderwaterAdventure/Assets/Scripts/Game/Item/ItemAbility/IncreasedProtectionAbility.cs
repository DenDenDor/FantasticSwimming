using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IncreasedProtectionAbility", menuName = "ScriptableObjects/ItemAbility/IncreasedProtectionAbility")]
public class IncreasedProtectionAbility : ItemAbility
{
    [SerializeField] private int _countOfArmorPoints = 4;
    private int _extraCountOfArmorPoints= 1;
    private int _currentCountOfAmorPoints;
    protected override void ActiveAbility()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.PlayerDamageHandler = new PlayerArmorPointsChanger(playerHealth.PlayerInformation,playerHealth,_currentCountOfAmorPoints);
        FindObjectsOfType<PlayerHealthOutPut>().Where(e=>e.DisplayerPlayerProtection is DisplayerPlayerArmorPoints).FirstOrDefault().ShowHealth();
        if (_currentCountOfAmorPoints < _countOfArmorPoints + _extraCountOfArmorPoints)
        {
            _currentCountOfAmorPoints ++;
        }
    }
    protected override void Start()
   {
    _currentCountOfAmorPoints = _countOfArmorPoints;
   }

}
