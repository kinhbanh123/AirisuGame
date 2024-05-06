using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCharacter : MonoBehaviour
{
    public Transform target; // Đối tượng mục tiêu mà bạn muốn đối tượng này nhìn về

    private void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        // Kiểm tra xem target đã được gán hay chưa
        if (target != null)
        {
            // Sử dụng hàm LookAt để đối tượng này nhìn về đối tượng mục tiêu
            Vector2 direction = target.position - transform.position;

            // Tính toán góc quay từ hướng
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Quay đối tượng để nhìn về đối tượng mục tiêu
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
