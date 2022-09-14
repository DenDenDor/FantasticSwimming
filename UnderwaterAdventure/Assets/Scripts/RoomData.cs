using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RoomData : ScriptableObject
{
    [SerializeField] public int numberScene = 0;
    [SerializeField] public List<RoomEnemy> roomEnemy;
}

[Serializable]
public class RoomEnemy
{
    [SerializeField] public Sprite Fon;
    [SerializeField] public GameObject[] Enemys;
    [SerializeField] public GameObject[] Artefacts;

    public int RangeEnemy() => UnityEngine.Random.Range(0, Enemys.Length);
    public int RangeArtefact() => UnityEngine.Random.Range(0, Artefacts.Length);

    //public GameObject SpawnEnemy(this GameObject[] T, Transform spawnPos) => MonoBehaviour.Instantiate(T[Range(T.Length)], spawnPos);

    public GameObject SpawnEnemy(Transform spawnPos) => MonoBehaviour.Instantiate(Enemys[RangeEnemy()], spawnPos);
    public GameObject SpawnArtefact(Transform spawnPos) => MonoBehaviour.Instantiate(Artefacts[RangeEnemy()], spawnPos);
}