using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAndDestroy : MonoBehaviour
{
    [SerializeField] int time;
    void Start()
    {
        StartCoroutine(Count(time));
    }

    IEnumerator Count(int sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
