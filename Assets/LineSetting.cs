using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineSetting : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Collider2D lineCollider2D;
    [SerializeField] float sizeBox;
    [SerializeField] float sizeLine;
    [SerializeField] int dmgByTouch;
    [SerializeField] GameObject endVfx;
    [SerializeField] float timeDelay;
    //x = 0.5
    void Start()
    {
        timeDelay = 5f;
        Vector3 vector = Vector3.zero;
        vector.y = 0.5f;
        lineRenderer.SetPosition(0, vector);
        lineRenderer.enabled = false;
        lineCollider2D.enabled = false;
        InvokeRepeating("shootLaser", 0f,timeDelay);
    }


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && this.gameObject.tag != "Enemy")
        {
            if (collision.GetComponent<TakeDps>() == null)
            {
                var dps = collision.AddComponent<TakeDps>();
                dps.Damage = 5;
                dps.Delay = 0.5f;
                dps.target = collision.GetComponent<Stats>();
            }
            
            /*Vector3 vector = Vector3.zero;
            
            vector.y = collision.transform.position.y-3;
            lineRenderer.SetPosition(1, vector);*/
            
            



        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && this.gameObject.tag != "Enemy")
        {
            Vector3 vector = Vector3.zero;
            /*vector.y = Vector2.Distance(GameObject.Find("Character").transform.position, collision.transform.position)+1;
            lineRenderer.SetPosition(1, vector);*/
            endVfx.SetActive(true);
            endVfx.transform.position = collision.transform.position;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && this.gameObject.tag != "Enemy")
        {
            if (collision.GetComponent<TakeDps>() != null)
            {

                collision.GetComponent<TakeDps>().Endthis();
            }

        }
        Vector3 vector = Vector3.zero;
        vector.y = 20f;
        lineRenderer.SetPosition(1, vector);
        endVfx.SetActive(false);
    }

    void shootLaser()
    {
        lineRenderer.enabled = true;
        lineCollider2D.enabled = true;
        StartCoroutine(wait(2));
        



    }

    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        lineRenderer.enabled = false;
        lineCollider2D.enabled = false;
    }


}
