using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class XPath : MonoBehaviour
{
    public List<GameObject> waypoints;
    public int NumberOfFollowLine;
    public float speed;
    int index = 0;
    public bool isLoop = true;
    public bool alreadyIn = false;
    void Start()
    {
        speed = 5f;
        Transform LineParent = GameObject.Find("LineforStg" + NumberOfFollowLine).transform;
        //int lenghtOfWp = LineParent.transform.childCount;


       /* for (int i = 0; i < lenghtOfWp; i++) 
       {
           
            string wpName = "wp (" + i+")";
            waypoints.Add(LineParent.Find(wpName).gameObject);
        
        }*/
        foreach (Transform childTransform in LineParent)
        {
            
            waypoints.Add(childTransform.gameObject);
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1 && speed != 2 && alreadyIn == false)
        { alreadyIn = true; speed = 2; }
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
    