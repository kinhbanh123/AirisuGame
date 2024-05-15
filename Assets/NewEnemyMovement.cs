using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    public float minX ; // Giới hạn tối thiểu của tọa độ x
    public float maxX ; // Giới hạn tối đa của tọa độ x
    public float minY = 3f; // Giới hạn tối thiểu của tọa độ y
    public float maxY = 12f; // Giới hạn tối đa của tọa độ y
    public float moveSpeed = 5f; // Tốc độ di chuyển

    private Rigidbody2D rb2D; // Tham chiếu đến Rigidbody2D của đối tượng
    private Vector2 targetPosition; // Vị trí mục tiêu tiếp theo của đối tượng
    float screen_x;
    float screen_y;
    void Start()
    {
        maxX = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().Maxscreen_x - 0.5f;
        minX = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().Minscreen_x + 0.5f;
        screen_y = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().screen_y;


        maxY = screen_y;





        rb2D = GetComponent<Rigidbody2D>();
        ChooseNewRandomPosition(); // Chọn một vị trí ngẫu nhiên ban đầu
    }

    void Update()
    {
        // Kiểm tra xem đối tượng đã đến gần vị trí mục tiêu hay chưa
        if (Vector2.Distance(rb2D.position, targetPosition) < 0.1f)
        {
            ChooseNewRandomPosition(); // Chọn một vị trí ngẫu nhiên mới khi đến gần vị trí mục tiêu
        }

        // Di chuyển đối tượng tới vị trí mục tiêu
        Vector2 moveDirection = (targetPosition - rb2D.position).normalized;
        moveDirection.y = Mathf.Clamp(moveDirection.y, -1f, 0f); // Chỉ cho phép di chuyển theo hướng y âm
        rb2D.velocity = moveDirection * moveSpeed;
    }

    void ChooseNewRandomPosition()
    {
        // Sinh ra tọa độ x và y ngẫu nhiên trong phạm vi xác định
        float randomX = Random.Range(minX,maxX); // Giới hạn tọa độ x trong khoảng -3 đến 3
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }
}
