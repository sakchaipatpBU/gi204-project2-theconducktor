using UnityEngine;

public class MelodySpawnManager : MonoBehaviour
{
    public GameObject[] melodyPrefabs;
    public Transform[] melodySpawnPoints;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnMelody), 1, 5);
    }


    void SpawnMelody()
    {
        int prefabIdx = Random.Range(0, melodyPrefabs.Length);
        int spawnIdx = Random.Range(0, melodySpawnPoints.Length);
        Instantiate(melodyPrefabs[prefabIdx], melodySpawnPoints[spawnIdx].transform.position, Quaternion.identity);
    }
}
