using UnityEngine;
using System.Collections.Generic;

public class BulletFly : MonoBehaviour
{
    [SerializeField] public int bulletSpeed;
     public GameObject target;

    void Update()
    {
        FindClosestTarget();

        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Gán giá trị cho rb ở đây

            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = direction * bulletSpeed;
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


}
