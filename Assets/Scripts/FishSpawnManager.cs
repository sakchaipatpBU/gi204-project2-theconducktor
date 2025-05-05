using UnityEngine;

public class FishSpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject prefab;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 2);
    }

    void Spawn()
    {
        if (Player.GetInstance().isGameOver == false)
        {
            int idx = Random.Range(0, spawnPoints.Length);
            Instantiate(prefab, spawnPoints[idx].transform.position, Quaternion.identity);
        }
    }
}
