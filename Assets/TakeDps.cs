using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDps : MonoBehaviour
{
    public Stats target { get; set; }
    public int Damage { get; set; }
    public float Delay { get; set; }


    void Start()
    {
        StartCoroutine(ApplyDamageOverTime());
    }
    IEnumerator ApplyDamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay); // Chờ 1 giây

            // Lấy component Stats từ đối tượng va chạm


            // Nếu đối tượng va chạm có component Stats
            
                // Gây sát thương cho đối tượng va chạm
                target.TakeDamage(Damage);
            
        }
    }


    public void Endthis()
    {
        Destroy(this);
    }
}
