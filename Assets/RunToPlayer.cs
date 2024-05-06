using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToPlayer : MonoBehaviour
{
    [SerializeField] public int timeAim;
    [SerializeField] public int Speed;
    public bool shoot=false;
    public bool special;
    public Transform target;
    Rigidbody2D rb;
    void OnEnable()
    {
        shoot = false;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        StartCoroutine(action());
    }
    
    void aim()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        rotation *= Quaternion.Euler(0, 0, 90);
        this.transform.rotation = rotation;

        // Thiết lập hướng di chuyển và tốc độ cho viên đạn
        this.GetComponent<Rigidbody2D>().velocity = direction * Speed;
       
    }

    IEnumerator action()
    {
        yield return new WaitForSeconds(timeAim);

        
        rb.constraints = RigidbodyConstraints2D.None;
        aim();
        if (special == true)
        {
            yield return new WaitForSeconds(2);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(2);
            rb.constraints = RigidbodyConstraints2D.None;
            aim();
        }
    }
}
