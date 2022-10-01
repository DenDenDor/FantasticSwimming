using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbility : ScriptableObject
{
   [SerializeField] private int _countForReloading = 1;
   [SerializeField] private string _description;
   private int _currentCoolDown;
   public int CountForReloading { get => _countForReloading; private set => _countForReloading = value; }
    public string Description { get => _description; private set => _description = value; }
    public int CurrentCoolDown { get => _currentCoolDown; private set => _currentCoolDown = value; }

    public void SetStartCountForReloading()
   {
    CurrentCoolDown = _countForReloading;
   }
   public void UseAbility()
   {
    if(CanUseAbility())
    {
    ActiveAbility();
    CurrentCoolDown = 0;
    }
   }
   public void IncreaseCoolDown()
   {
      CurrentCoolDown++;
   }
   private bool CanUseAbility()
   {
    return CurrentCoolDown >= CountForReloading;
   }
   protected abstract void ActiveAbility();
}
