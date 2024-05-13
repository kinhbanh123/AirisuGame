using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected GameObject holder;
    [SerializeField] protected List<GameObject> bulletPool;
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform target; // Đối tượng mục tiêu
    public float bulletSpeed = 5f; // Tốc độ di chuyển của viên đạn
    public float fireRate; // Tốc độ bắn (số viên đạn bắn mỗi giây)
    public bool ShootSTR;
    public bool cd = false;
    private float nextFireTime; // Thời gian cho đến lần bắn tiếp th
    private void Start()
    {
        this.LoadHolder();
        bulletPool = holder.GetComponent<PoolEnemy>().bulletPool;
        StartCoroutine(wait1sec());
        fireRate = Random.Range(0.1f, 1f);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nextFireTime = Time.time + 6f;
    }

    void Update()
    {
        // Kiểm tra nếu đã đến thời điểm bắn tiếp theo
        if (Time.time >= nextFireTime)
        {

            if (cd == true)
            { // Gọi hàm bắn
                Shoot();
            }
            // Cập nhật thời điểm bắn tiếp theo
            nextFireTime = Time.time + 1f / fireRate;
            fireRate = Random.Range(0.1f, 1f);
        }
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("HolderEnemy");

    }



    void Shoot()
    {
        
        if (!ShootSTR)
        {
            // Kiểm tra nếu có đối tượng mục tiêu
            if (target != null)
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = GetBulletFromPool();
                // Tạo một viên đạn tại vị trí của vật bắn

                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.transform.parent = this.holder.transform;
                // Tính toán hướng di chuyển tới đối tượng mục tiêu
                Vector3 direction = (target.position - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                rotation *= Quaternion.Euler(0, 0, 90);
                // Thiết lập hướng và tốc độ di chuyển của viên đạn
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                // Thiết lập hướng di chuyển và tốc độ cho viên đạn
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }
        }
        else
        {
            //GameObject bullet = Instantiate(bulletPrefab);
            GameObject bullet = GetBulletFromPool();
            // Tạo một viên đạn tại vị trí của vật bắn

            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.transform.parent = this.holder.transform;
            Vector3 direction = Vector3.down;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            rotation *= Quaternion.Euler(0, 0, 90);
            // Thiết lập hướng và tốc độ di chuyển của viên đạn
            bullet.transform.rotation = rotation;
            // Thiết lập hướng di chuyển và tốc độ cho viên đạn
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    
    }
    IEnumerator wait1sec()
    {
        yield return new WaitForSeconds(1.5f);
        cd = true;
    }

    GameObject GetBulletFromPool()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy && bullet.name == bulletPrefab.name)
            {
                
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.parent = holder.transform;
        bulletPool.Add(newBullet);
        return newBullet;
    }





}
