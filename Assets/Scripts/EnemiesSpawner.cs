using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    //public
    [Tooltip("drag and drop Enemy prefab")]
    public GameObject EnemyPrefab;
    [Tooltip("write down Room length")]
    public float RoomLength;
    [Tooltip("number of enemies in the pool")]
    public int ObjectPoolLength;
    //Private
    private int currentlength = 0;
    private float SpawningTime = 0;
    private List<GameObject> EnemiesPool;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesPool = new List<GameObject>();
        if (ObjectPoolLength > 0)
            for (int i = 0; i < ObjectPoolLength; i++)
                EnemiesPool.Add(Instantiate(EnemyPrefab));
    }
    private void Update()
    {
        SpawnEnemy();
    }
    /// <summary>
    /// spawns an enemy every 2 seconds
    /// </summary>
    private void SpawnEnemy()
    {
        SpawningTime += Time.deltaTime;
        if (SpawningTime >= 1)
        {
            var nx = Random.Range(-RoomLength, RoomLength);
            var nz = Random.Range(2, RoomLength);
            EnemiesPool[currentlength].transform.position = new Vector3(nx, 0.5f, nz);
            EnemiesPool[currentlength].SetActive(true);
            currentlength = (currentlength + 1) % ObjectPoolLength;
            SpawningTime = 0;
        }
    }
}
