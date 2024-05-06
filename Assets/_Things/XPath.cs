using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPath : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;
    void Start()
    {
      int lenghtOfWp = GameObject.Find("LineforStg").transform.childCount;


        for (int i = 0; i < lenghtOfWp; i++) 
        {
           
            string wpName = "wp (" + i+")";
            waypoints.Add(GameObject.Find(wpName));

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 destination = waypoints[index].transform.position;
        Vector2 newPos = Vector2.MoveTowards(transform.position, destination, speed*Time.deltaTime);
        transform.position = newPos;
        float distance = Vector2.Distance(transform.position, destination);
        if (distance < 0.05f)
        {
            if(index <waypoints.Count - 1) { index++; }
            else
            {
                if(isLoop) 
                { index = 0; } 
            }
        }
    }
}
    