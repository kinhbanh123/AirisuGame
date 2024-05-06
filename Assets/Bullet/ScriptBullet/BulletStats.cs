using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BulletStats : MonoBehaviour
{
    public bool Enemy;
    public int damage = 10; // Sát thương của viên đạn
    [SerializeField] GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Enemy == true)
        { 

        if (collision.gameObject.tag == "Player")
        { 

        // Lấy component Health từ đối tượng va chạm
        Stats targetHp = collision.gameObject.GetComponent<Stats>();

        // Nếu đối tượng va chạm có component Health
        if (targetHp != null)
        {
            // Gây sát thương cho đối tượng va chạm
            targetHp.TakeDamage(damage);
        }

        // Huỷ bỏ viên đạn sau khi va chạm
        Destroy(gameObject);
        }
        }
        else if (Enemy == false) 
        {
            if (collision.gameObject.tag == "Enemy")
            {

                // Lấy component Health từ đối tượng va chạm
                Stats targetHp = collision.gameObject.GetComponent<Stats>();

                // Nếu đối tượng va chạm có component Health
                if (targetHp != null)
                {
                    // Gây sát thương cho đối tượng va chạm
                    targetHp.TakeDamage(damage);
                }
                GameObject hits = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
                // Huỷ bỏ viên đạn sau khi va chạm
                gameObject.SetActive(false);
            }
        }
    }
    
}
