using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbility : ScriptableObject
{
   [SerializeField] private int _countForReloading = 1;
   [SerializeField] private string _description;
   [SerializeField] private string _fullDescription;
   private int _currentCoolDown;
   public int CountForReloading { get => _countForReloading; private set => _countForReloading = value; }
    public string Description { get => _description; private set => _description = value; }
    public int CurrentCoolDown { get => _currentCoolDown; private set => _currentCoolDown = value; }
    public string FullDescription { get => _fullDescription; set => _fullDescription = value; }
    public event Action<ItemAbility> OnClick;
    public void SetStartCountForReloading()
   {
    CurrentCoolDown = _countForReloading;
    Start();
   }
   public void UseAbility()
   {
    if(CanUseAbility())
    {
    OnClick?.Invoke(this);       
    Debug.Log(" HU HU! ");
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
   protected virtual void Start()
   {

   }
   protected abstract void ActiveAbility();
}
