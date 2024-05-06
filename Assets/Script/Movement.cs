using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 worldPosition;
    [SerializeField] Vector3 oldpos;
    [SerializeField] public float speed = 0.1f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    public Animator animator;
    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving(); 
    }
    private void Start()
    {
        maxX = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().screen_x;
        minX = -maxX;
        maxY = GameObject.Find("ScreenInfo").GetComponent<ScreenInfo>().screen_y;


        oldpos = this.transform.position;
        //animator = gameObject.GetComponent<Animator>();
    }
    protected virtual void GetTargetPosition()
    {
        this.worldPosition = InputManager.instance.mouseWorldPos;
        if (this.worldPosition.x>maxX)
        {
            this.worldPosition.x = maxX;
        }
        if (this.worldPosition.x < minX)
        {
            this.worldPosition.x = minX;
        }
        if (this.worldPosition.y < 3)
        {
            this.worldPosition.y = 3;
        }
        if (this.worldPosition.y > maxY-1)
        {
            this.worldPosition.y = maxY-1;
        }
        this.worldPosition.z = 0;

    }
    
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed);
        float deltaPosX = newPos.x - oldpos.x;

        if (deltaPosX < -0.05f) // Di chuyển sang trái
        {
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", true);
        }
        else if (deltaPosX > 0.05f) // Di chuyển sang phải
        {
            animator.SetBool("TurnLeft", false);
            animator.SetBool("TurnRight", true);
        }
        else // Không di chuyển hoặc di chuyển rất ít
        {
            animator.SetBool("TurnLeft", false);
            animator.SetBool("TurnRight", false);
        }

        oldpos = this.transform.position;
        transform.position = newPos;
    }
    



}





  
        
       
           

        






