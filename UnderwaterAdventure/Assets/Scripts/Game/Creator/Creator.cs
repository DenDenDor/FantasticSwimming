using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Creator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    public T Prefab { get => _prefab; protected set => _prefab = value; }

    public T Create(Vector3 position)
   {
     return Instantiate(Prefab,position,Quaternion.identity);
   }
}
