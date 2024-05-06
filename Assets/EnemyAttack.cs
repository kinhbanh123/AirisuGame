using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected GameObject holder;
    [SerializeField] protected List<GameObject> bulletPool = new List<GameObject>();
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform target; // Đối tượng mục tiêu
    public float bulletSpeed = 5f; // Tốc độ di chuyển của viên đạn
    public float fireRate = 1f; // Tốc độ bắn (số viên đạn bắn mỗi giây)
    public bool ShootSTR;
    public bool cd = false;
    private float nextFireTime; // Thời gian cho đến lần bắn tiếp th
    private void Start()
    {
        StartCoroutine(wait1sec());
        this.LoadHolder();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
                GameObject bullet = Instantiate(bulletPrefab);
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

                // Thiết lập hướng di chuyển và tốc độ cho viên đạn
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab);
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

            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    
    }
    IEnumerator wait1sec()
    {
        yield return new WaitForSeconds(1.5f);
        cd = true;
    }

}
