using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoss : MonoBehaviour
{
    [SerializeField] protected GameObject holder;
    [SerializeField] protected GameObject warningSign;
    [SerializeField] protected GameObject boss;
    GameObject Bosu;
    // Start is called before the first frame update
    void Start()
    {
        this.LoadHolder();
        int randomValueY = Random.Range(13, 16);
        Debug.Log("Warning");
        StartCoroutine(waitsec(5f));
        Vector3 spawnPosition = new Vector3(0, randomValueY, 0);
        Bosu = Instantiate(boss, spawnPosition, Quaternion.Euler(20f, 180f, 0f));
        GameObject.Find("GameControl").GetComponent<GameControl>().numberEnemy = GameObject.Find("GameControl").GetComponent<GameControl>().numberEnemy * 3 - GameObject.Find("GameControl").GetComponent<GameControl>().numberEnemy*2;
    }

    private void Update()
    {
        if (Bosu  == null)
        {

            Destroy(gameObject);
        }
    }

    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("EnemyHolder");
    }
    IEnumerator waitsec(float sec)
    {
        yield return new WaitForSeconds(sec);

    }
    
}
