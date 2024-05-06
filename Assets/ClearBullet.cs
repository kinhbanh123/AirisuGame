using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBullet : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        //if (other.gameObject.CompareTag("Enemy"))
       // {
           // Destroy(other.gameObject);
       // }
        if (other.gameObject.CompareTag("DropItem"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("SupriseThing"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
