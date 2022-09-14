using UnityEngine;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour
{
    [SerializeField] private RoomData roomData;

    [SerializeField] private Image fonPlayEnemy;
    [SerializeField] private GameObject enemyPoint;
    [SerializeField] private GameObject artivactPoint;

    private RoomEnemy enemy;
    private GameObject artefact;

    public void SetActiveRoomEnemy()
    {
        enemy = roomData.roomEnemy[roomData.numberScene];
        fonPlayEnemy.sprite = enemy.Fon;
        enemy.SpawnEnemy(enemyPoint.transform);
        artefact = enemy.SpawnArtefact(artivactPoint.transform);
        artefact.SetActive(false);
    }
}