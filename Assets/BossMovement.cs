using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossMovement : MonoBehaviour
{
    public Transform target;

    protected GameObject holder;
    [SerializeField] Animator animator;
    [SerializeField] int hp;
    [SerializeField] int maxhp;
    [SerializeField] Stats stats;
    public GameObject[] bulletPrefab;
    [SerializeField] GameObject[] creep;
    public float bulletSpeed = 5f; // Tốc độ di chuyển của viên đạn
    public float fireRate = 1f;
    private float nextFireTime;
    public int numberOfBullets;
    private bool specialMove;
    public float moveSpeed = 5f; // Tốc độ di chuyển
    private Rigidbody2D rb2D; // Tham chiếu đến Rigidbody2D của đối tượng
    private Vector2 targetPosition; // Vị trí mục tiêu tiếp theo của đối tượng
    float screen_x;
    float screen_y;

    void Start()
    {
        screen_x = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().screen_x;
        screen_y = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().screen_y;
        specialMove = true;
        this.LoadHolder();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        maxhp = stats.maxHp;
        ChooseNewRandomPosition();
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("HolderEnemy");
    }

    void Update()
    {
        hp = stats.currentHp;

        // Kiểm tra xem đối tượng đã đến gần vị trí mục tiêu hay chưa

        if (Vector2.Distance(rb2D.position, targetPosition) < 0.1f)
        {
            ChooseNewRandomPosition(); // Chọn một vị trí ngẫu nhiên mới khi đến gần vị trí mục tiêu
        }
        if (hp < maxhp / 2 && specialMove==true) { StartCoroutine(spawnCreepMove()); }
        // Di chuyển đối tượng tới vị trí mục tiêu


       
            Vector2 moveDirection = (targetPosition - rb2D.position).normalized;
            rb2D.velocity = moveDirection * moveSpeed;
            // Di chuyển đối tượng tới vị trí mục tiêu


        if (Time.time >= nextFireTime)
        {

            normalMove();
            nextFireTime = Time.time + 1f / fireRate;

        }

    }

    void normalMove()
    {

        if (target != null)
        {
            animator.SetTrigger("NormalAttack");
            Vector3 direction = (target.position - transform.position).normalized;
            float spread = 1.25f;

            int random = Random.Range(0, 100);
            if (random > 50) { direction.x = direction.x - spread; }
            else { direction.x = direction.x + spread; }
            for (int i = 0; i < numberOfBullets; i++)
            {
                if (i > 0 && random > 50) { direction.x = direction.x + spread; }
                if (i > 0 && random < 50) { direction.x = direction.x - spread; }
                GameObject bullet = Instantiate(bulletPrefab[0]);
                // Tạo một viên đạn 0 tại vị trí của vật bắn

                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.transform.parent = this.holder.transform;
                // Tính toán hướng di chuyển tới đối tượng mục tiêu

                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                rotation *= Quaternion.Euler(0, 0, 90);
                // Thiết lập hướng và tốc độ di chuyển của viên đạn
                bullet.transform.rotation = rotation;

                // Thiết lập hướng di chuyển và tốc độ cho viên đạn
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }
        }
    }

    IEnumerator spawnCreepMove()
        {
        specialMove = false;
        int pick = Random.Range(0, creep.Length);
        for (int j = 0;j<3;j++)
        {
        for (int i = 0; i < 9; i++)
            {
                float randomValueX = Random.Range(-screen_x, screen_x);
                float randomValueY = Random.Range(screen_y+1, screen_x+3);
                Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0); // Ví dụ: Sinh ra tại vị trí (0, 0, 0)
                Instantiate(creep[pick], spawnPosition, Quaternion.identity);

                // Sau khi sinh ra một đối tượng mới, cập nhật lại numberOfEnemy
               
            
            }
        yield return new WaitForSeconds(2f);
        }

        
        }






    


    void ChooseNewRandomPosition()
    {
        float minX = -screen_x-1; // Giới hạn tối thiểu của tọa độ x
        float maxX = screen_x+1; // Giới hạn tối đa của tọa độ x
        float minY = screen_y/2; // Giới hạn tối thiểu của tọa độ y
        float maxY = screen_y+0.5f; // Giới hạn tối đa của tọa độ y
        // Sinh ra tọa độ x và y ngẫu nhiên trong phạm vi xác định
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }




}
