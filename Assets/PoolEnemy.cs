using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] public List<GameObject> bulletPool = new List<GameObject>();
    [SerializeField] public GameObject[] bulletPrefab;
    [SerializeField] protected GameObject holder;
    void Start()
    {
        LoadBulletPool();
    }
    void LoadBulletPool()
    {
        for (int j =0; j < bulletPrefab.Length; j++) 
        {
        for (int i = 0; i < 10; i++) // Thay đổi số lượng đối tượng trong pool tùy theo nhu cầu
        {
            GameObject bullet = Instantiate(bulletPrefab[j]);
            bullet.SetActive(false);
                bullet.name = bulletPrefab[j].name;
                bullet.transform.parent = holder.transform;
            bulletPool.Add(bullet);
        }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
