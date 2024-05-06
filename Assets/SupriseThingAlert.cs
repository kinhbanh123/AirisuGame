using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupriseThingAlert : MonoBehaviour
{
    [SerializeField] GameObject[] sign;
    void OnTriggerEnter2D(Collider2D collision)
    {
        RunToPlayer checkstats = collision.gameObject.GetComponent<RunToPlayer>();
        if (collision.gameObject.tag == "SupriseThing" && checkstats.shoot == false)
        {
            Vector3 pos = collision.transform.position;
            if (pos.x >0)
            {
                pos.x = 2f;
            }
            if (pos.x <0)
            {
                pos.x = -2f;
            }
           GameObject signs = Instantiate(sign[0],pos, Quaternion.identity);
            
        }
        if (collision.gameObject.tag == "SupriseThing" && checkstats.shoot == true)
        {
            collision.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision )
    {
        RunToPlayer checkstats = collision.gameObject.GetComponent<RunToPlayer>();



        if (collision.gameObject.tag == "SupriseThing" && checkstats.shoot == false)
        {
            checkstats.shoot = true;
            

        }
    }

}
