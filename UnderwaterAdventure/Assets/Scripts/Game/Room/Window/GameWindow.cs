using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class GameWindow : MonoBehaviour
{
   protected Action OnDestroy;
   public AdditionalSlotCreator FindAdditionalSlotCreatorOnScene<T>() where T : GameWindow
   {
     AdditionalSlotCreator additionalSlotCreator = FindObjectsOfType<AdditionalSlotCreator>().FirstOrDefault(e=>e.GameWindow is T);
     OnDestroy +=  additionalSlotCreator.DestroyCreatedSlots;
     return additionalSlotCreator;
   }
}
