using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{

    [SerializeField] public float bulletSpeed;

    private void Start()
    {
        bulletSpeed = 10f;
    }
    void Update()
    {
        //this.transform.Rotate(Vector3.forward, bulletRotation);
        Rigidbody2D bulletRigidbody = this.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.up * bulletSpeed;

    }
}
