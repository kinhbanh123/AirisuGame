using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{

    Vector3 startPos;
    float repeatHeight;
    void Start()
    {
        startPos = transform.position;
        float repeatHeight = GetComponent<BoxCollider2D>().size.y /2 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y- 10) 
        {transform.position = startPos;

        }
    }
}
