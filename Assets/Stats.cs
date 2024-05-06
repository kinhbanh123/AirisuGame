using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public int maxHp;
    [SerializeField] public int currentHp;
    [SerializeField] GameObject deathEffect;
    [SerializeField] bool Player;

    [SerializeField] protected float DamageDelay = 10f;
    [SerializeField] protected float DamageTimer = 10f;
    [SerializeField] GameObject shield;
    

    void Start()
    {
        if (Player == false) { maxHp = maxHp + 4 * GameObject.Find("Enemy").GetComponent<StageSystem>().StageNumber; }
        currentHp = maxHp;
        
    }
    public void TakeDamage(int damage)
    {
        if (Player == true)
        {

            if (this.DamageTimer >= this.DamageDelay)
            { 
            this.DamageTimer = 0f;
            currentHp -= damage; // Giảm máu
                shield.SetActive(true);
            // Kiểm tra nếu máu hiện tại <= 0
            if (currentHp <= 0)
            {
                Die(); // Gọi hàm Die khi máu <= 0
            } 
            }
        }
        else
        {
            currentHp -= damage; // Giảm máu

            // Kiểm tra nếu máu hiện tại <= 0
            if (currentHp <= 0)
            {
                Die(); // Gọi hàm Die khi máu <= 0
                
            }

        }
    }
    private void Update()
    {
        if (Player == true)
        {
            this.DamageTimer += Time.fixedDeltaTime;
            if (this.DamageTimer >= this.DamageDelay && shield != null)
                shield.SetActive(false);
        }
        if (Player == false)
        {
            if (this.transform.position.y < 2)
            {
                Destroy(gameObject);
            }
        }
    }
    void Die()
    {
        // Xử lý khi mục tiêu chết
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject); // Huỷ bỏ đối tượng
        if (this.gameObject.tag == "Enemy")
        {
            DropItem dropItemComponent = this.gameObject.GetComponent<DropItem>();
            if (dropItemComponent != null)
            {
                dropItemComponent.CountAndDrop();
                dropItemComponent.PlusExp();
            }
        }
        Destroy(gameObject);
    }
}
