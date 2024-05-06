using UnityEngine;
using System.Collections.Generic;

public class BulletFly : MonoBehaviour
{
    public float bulletSpeed = 5f; // Giảm tốc độ của viên đạn
    public GameObject target;
    public GameObject bulletPrefab;

    void Update()
    {
        FindClosestTarget();

        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            FireBullet(direction);
        }
    }

    void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy;
    }

    void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Kích hoạt Rigidbody của viên đạn
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed;

        // Đặt hướng quay của viên đạn để nó nhìn theo hướng di chuyển
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletRb.rotation = angle - 90f; // -90 là để chỉnh lại góc ban đầu của viên đạn
    }
}
