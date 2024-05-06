using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyMovement : MonoBehaviour
{
    public float moveDistance = 1f; // Khoảng cách tối đa mà vật thể có thể di chuyển
    public float moveSpeed = 1f; // Tốc độ di chuyển

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector3 moveDirection;

    void Start()
    {
        initialPosition = transform.position;
        GetNewTargetPosition();
    }

    void Update()
    {
        // Di chuyển vật thể theo hướng mới
        if (this.transform.position.y > 12)
        { moveSpeed = 10f; }
        else
        { moveSpeed = 1f; }

       if (this.transform.position.x < -2.5f)
        {
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            ForceMovement(-2.5f);

        }
        else if (this.transform.position.x > 2.5f)
        {
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            ForceMovement(2.5f);
        }
        else
        
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        // Nếu vật thể đã đến gần đích, chọn một đích mới
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            GetNewTargetPosition();
        }
    }
    void ForceMovement(float x)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = x;

        // Cập nhật vị trí của đối tượng
        transform.position = currentPosition;
    }
    void GetNewTargetPosition()
    {

        float newX = Random.Range(initialPosition.x - moveDistance, initialPosition.x + moveDistance);
        float newY = Random.Range(initialPosition.y - moveDistance, initialPosition.y + moveDistance);

        
        if (newY < 1)
        {
            newY = 2f;
        }


        if (this.gameObject.name[0] == '@')
        {
            if (newY > 12)
            {
                newY = 9.5f;
            }
            if (newX > 2.5f)
            {
                newX = 2.5f;
            }
            if (newX < -2.5f)
            {
                newX = -2.5f;
            }
        }
        else
        {
            if (newX > 2.5f)
            {
                newX = 2.5f;
            }
            if (newX < -2.5f)
            {
                newX = -2.5f;
            }
            if (newY > 12)
            {
                newY = 11.5f;
            }
        }


        targetPosition = new Vector3(newX, newY, initialPosition.z);

        // Xác định hướng di chuyển mới
        moveDirection = (targetPosition - transform.position).normalized;
    }

}
