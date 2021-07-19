using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemies;
    public float RoomLength;
    public int ObjectPoolLength;
    private int currentlength = 0;
    private float SpawningTime = 0;
    private List<GameObject> EnemiesPool;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesPool = new List<GameObject>();
        if (ObjectPoolLength > 0)
            for (int i = 0; i < ObjectPoolLength; i++)
                EnemiesPool.Add(Instantiate(Enemies));
    }
   
    private void Update()
    {
        SpawningTime += Time.deltaTime;
        if (SpawningTime >= 2)
        {
            var nx = Random.Range(-RoomLength, RoomLength);
            var nz = Random.Range(0, RoomLength);
            EnemiesPool[currentlength].transform.position = new Vector3(nx, 0.5f, nz);
            EnemiesPool[currentlength].SetActive(true);
            currentlength = (currentlength + 1) % ObjectPoolLength;
            SpawningTime = 0;
        }
    }
  
}
