using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KronieBossMove : MonoBehaviour
{
    private Vector2 targetPosition;
    public float moveSpeed = 5f; // Tốc độ di chuyển
    private Rigidbody2D rb2D; // Tham chiếu đến Rigidbody2D của đối tượng
    public float rotationSpeed = 100f;
    public float targetRotation = 360f;


    public GameObject bulletPrefab; // Prefab của viên đạn
    public float bulletSpeed = 10f; // Tốc độ của viên đạn
    public float fireRate = 0.5f; // Tần suất bắn (số lần bắn mỗi giây)
    private bool isShooting = true;
    private float saveSpeed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ChooseNewRandomPosition();
        StartCoroutine(ExecuteEvery10Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb2D.position, targetPosition) < 0.1f)
        {
            ChooseNewRandomPosition(); // Chọn một vị trí ngẫu nhiên mới khi đến gần vị trí mục tiêu
        }
        Vector2 moveDirection = (targetPosition - rb2D.position).normalized;
        rb2D.velocity = moveDirection * moveSpeed;





    }
    void ChooseNewRandomPosition()
    {
        float minX = -2f; // Giới hạn tối thiểu của tọa độ x
        float maxX = 2f; // Giới hạn tối đa của tọa độ x
        float minY = 7f; // Giới hạn tối thiểu của tọa độ y
        float maxY = 11.5f; // Giới hạn tối đa của tọa độ y
        // Sinh ra tọa độ x và y ngẫu nhiên trong phạm vi xác định
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }
    void SpinMove()
    {
        saveSpeed = moveSpeed;
        moveSpeed = 0;
        isShooting = true;
        StartCoroutine(RotateObject());
        StartCoroutine(ContinuousShoot());


    }
    IEnumerator RotateObject()
    {
        float currentRotation = 0f; // Góc quay hiện tại của vật

        // Lặp cho đến khi vật đạt được góc quay cố định
        while (currentRotation < targetRotation)
        {
            // Tính toán góc quay mới dựa trên tốc độ xoay
            float rotationStep = rotationSpeed * Time.deltaTime;
            currentRotation += rotationStep;

            // Xoay vật
            transform.Rotate(Vector3.forward, rotationStep);

            yield return null; // Chờ cho frame tiếp theo
        }
        StopShooting();
        moveSpeed = saveSpeed;

    }
    IEnumerator ContinuousShoot()
    {
        // Lặp liên tục cho đến khi biến trạng thái là false
        while (isShooting)
        {
            Shoot(); // Bắn đạn
            yield return new WaitForSeconds(1f / fireRate); // Chờ một khoảng thời gian giữa các lần bắn
        }
    }
    void Shoot()
    {
        // Tạo một đối tượng đạn từ prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Lấy hướng phía trước của vật
        Vector3 shootDirection = transform.right;
        Vector3 shootDirection2 = -transform.right;
        // Thiết lập tốc độ di chuyển của viên đạn theo hướng phía trước
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = shootDirection2 * bulletSpeed;
    }

    // Hàm này sẽ được gọi từ bên ngoài để dừng việc bắn
    public void StopShooting()
    {
        isShooting = false;
    }
    IEnumerator ExecuteEvery10Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Chờ 10 giây

            SpinMove();
            Debug.Log("This command runs every 10 seconds.");
        }
    }
}
