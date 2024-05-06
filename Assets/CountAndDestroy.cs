using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountAndDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int childCount = transform.childCount;
        if (childCount ==0)
        {
            Destroy(gameObject);
        }
    }
}
