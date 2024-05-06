using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    [SerializeField] float time;
    void Start()
    {
        // Gọi coroutine để chờ đợi và xoá đối tượng sau 2 giây
        StartCoroutine(DestroyAfterDelay(time));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // Chờ đợi trong một khoảng thời gian
        yield return new WaitForSeconds(delay);

        // Sau khi chờ đợi, xoá đối tượng
        Destroy(gameObject);
    }
}
