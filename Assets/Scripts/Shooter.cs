using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public int BulletPoollength;
    private List<GameObject> bulletPool;
    private int currentBullet = 0;
    // Start is called before the first frame update
    private void Start()
    {
        bulletPool = new List<GameObject>();
        if (BulletPoollength > 0)
        {
            for (int i = 0; i < BulletPoollength; i++)
                bulletPool.Add(Instantiate(Bullet));
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Ended)
                ShootBullet();
            else if (Input.GetMouseButtonUp(0))
                ShootBullet();
    }
    private void ShootBullet()
    {
        bulletPool[currentBullet].transform.position = transform.position;
        bulletPool[currentBullet].SetActive(true);
        bulletPool[currentBullet].GetComponent<Rigidbody>().AddForce(10 * transform.forward, ForceMode.Impulse);
        currentBullet = (currentBullet + 1) % BulletPoollength;
    }
}
