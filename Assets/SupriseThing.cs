using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupriseThing : MonoBehaviour
{
    [SerializeField] public GameObject[] SupriseGift;
    [SerializeField] public int chance;
    [SerializeField] int n = 1;
    [SerializeField] protected GameObject holder;
    [SerializeField] protected List<GameObject> bulletPool = new List<GameObject>();

    void Start()
    {
        this.LoadHolder();
        // Khởi tạo danh sách bulletPool nếu chưa được khởi tạo
        if (bulletPool == null)
        {
            bulletPool = new List<GameObject>();
        }
        InvokeRepeating("SpawnSupriseThing", 0f, 10f); //shoot
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("EnemyHolder");
    }

    void SpawnSupriseThing()
    {
        int random = Random.Range(0, 100);
        if (random <= chance)
        {
            n = Mathf.Clamp(n + 1, 0, 6); // Giới hạn giá trị của n trong khoảng từ 0 đến 6
            for (int i = 0; i < n; i++)
            {
                int pick = Random.Range(0, SupriseGift.Length);
                int randomValueX = 5;
                int randomValueY = Random.Range(3, 12);
                int lastrandom = Random.Range(0, 99);
                if (lastrandom > 50) { randomValueX *= -1; }
                Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0);
                GameObject bullet = GetBulletFromPool(pick, spawnPosition);
                bullet.transform.position = spawnPosition;


                bullet.transform.parent = this.holder.transform;
                bullet.SetActive(true);
            }
        }
    }

    GameObject GetBulletFromPool(int pick, Vector3 spawnPosition)
    {
        // Kiểm tra nếu bulletPool chưa được khởi tạo hoặc là null
        if (bulletPool == null)
        {
            bulletPool = new List<GameObject>();
        }

        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        // Nếu không có bullet nào trong pool, thêm một bullet mới vào pool
        GameObject newBullet = Instantiate(SupriseGift[pick], spawnPosition, Quaternion.identity);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
