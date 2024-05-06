using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected GameObject holder;
    [SerializeField] protected float shootDelay;
    [SerializeField] public float shootTimer = 0f;
    public Transform firePoint;
    float bulletRotation = 90f;
    [SerializeField] string type;
    [SerializeField] protected List<GameObject> bulletPool = new List<GameObject>();
    public float bulletSpeed = 10f;

    void Start()
    {
        shootDelay = GameObject.Find("Character").GetComponent<PlayerInfo>().checkNameAndStat(type);
        this.LoadHolder();
        LoadBulletPool();
        
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("Holder");

    }


    void LoadBulletPool()
    {
        for (int i = 0; i < 10; i++) // Thay đổi số lượng đối tượng trong pool tùy theo nhu cầu
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    void Update()
    {
        shootDelay = GameObject.Find("Character").GetComponent<PlayerInfo>().checkNameAndStat(type);
        Shoot();
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootDelay)
        {
            shootTimer = 0f;
            GameObject bullet = GetBulletFromPool();
            
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<ClearTrail>().countAndClear();
            bullet.transform.parent = this.holder.transform;
            bullet.transform.Rotate(Vector3.forward, bulletRotation);
            bullet.SetActive(true);

        }
    }

    GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(bulletPrefab);
        
        bulletPool.Add(newBullet);
        return newBullet;
    }

}
