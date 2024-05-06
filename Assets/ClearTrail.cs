using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrail : MonoBehaviour
{
    [SerializeField] GameObject[] Trails;

    public void countAndClear()
    {
        for (int i = 0; i < Trails.Length; i++) 
        {
            Trails[i].GetComponent<TrailRenderer>().Clear();
        }
    }

}
