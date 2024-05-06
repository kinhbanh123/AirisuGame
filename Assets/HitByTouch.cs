using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByTouch : MonoBehaviour
{
    [SerializeField] public int dmgByTouch;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            // Lấy component Health từ đối tượng va chạm
            Stats targetHp = collision.gameObject.GetComponent<Stats>();

            // Nếu đối tượng va chạm có component Health
            if (targetHp != null)
            {
                // Gây sát thương cho đối tượng va chạm
                targetHp.TakeDamage(dmgByTouch);
            }
        }



        if (collision.gameObject.tag == "Enemy" && this.gameObject.tag != "Enemy")
        {
            
            // Lấy component Health từ đối tượng va chạm
            Stats targetHp = collision.gameObject.GetComponent<Stats>();

            // Nếu đối tượng va chạm có component Health
            if (targetHp != null)
            {
                // Gây sát thương cho đối tượng va chạm
                targetHp.TakeDamage(dmgByTouch);
            }

            // Huỷ bỏ viên đạn sau khi va chạm
        }


    }
}
