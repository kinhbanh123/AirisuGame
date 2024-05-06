using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Transform target; // Vật mà vật hiện tại sẽ xoay quanh
    public float orbitSpeed = 1f; // Tốc độ xoay
    public float orbitRadius = 1f; // Bán kính quay
    public float angle; // Góc xoay
    public float Speed;
    Rigidbody2D rb;
    public Transform targetATK;
    private Vector3 initialPosition;
    private Vector3 axisOfRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetATK = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (target != null)
        { 
        initialPosition = transform.position;
        axisOfRotation = (transform.position - target.position).normalized;
        }
    }
    void Update()
    {
        // Nếu không có mục tiêu, không làm gì cả
        if (target == null)
        { aim(); }
        else 
        {
            float x = target.position.x + Mathf.Sin(angle) * orbitRadius;
            float y = target.position.y + Mathf.Cos(angle) * orbitRadius;
            Vector3 orbitPosition = new Vector3(x, y, transform.position.z);

            // Đặt vị trí của vật hiện tại là vị trí xoay quanh mục tiêu
            transform.position = orbitPosition;
            
            // Tăng góc xoay để tạo hiệu ứng quay
            angle += orbitSpeed * Time.deltaTime;
        }
    }
    void aim()
    {
        Vector3 direction = (targetATK.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);


        rb.constraints = RigidbodyConstraints2D.None;
        this.GetComponent<Rigidbody2D>().velocity = direction * 3;
        
    }
}
   
    
        // Nếu không có mục tiêu hoặc mục tiêu bị huỷ, không làm gì cả
        
        // Tính toán hướng quay mới của vật
        /*Quaternion rotation = Quaternion.AngleAxis(orbitSpeed * Time.deltaTime, axisOfRotation);

        // Cập nhật vị trí của vật xung quanh mục tiêu
        Vector3 newPosition = rotation * (transform.position - target.position) + target.position;

        // Giữ vật ở cố định bán kính quay
        newPosition = target.position + (newPosition - target.position).normalized * orbitRadius;

        // Cập nhật vị trí của vật
        transform.position = newPosition;*/

    
