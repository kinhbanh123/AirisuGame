using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    [SerializeField] bool randomCheck;
    [SerializeReference] bool moreEnemyType;
    [SerializeField] public bool WhatIsHappenRightNow;
    [SerializeField] private int numberOfEnemy;
    [SerializeField] public int maxNumberOfEnemy;
    [SerializeField] public GameObject[] EnemyToSpawn;
    [SerializeField] public GameObject[] StageToSpawn;
    [SerializeField] protected GameObject holder;
    [SerializeField] int count ;
    
    private void Start()
    {
        this.LoadHolder();
        count = 0;
        //InvokeRepeating("spawn", 5f, 0f);
        
        
        if (randomCheck == false)
        {
            int randomStageX = Random.Range(0, StageToSpawn.Length);
            Vector3 newPosition = new Vector3(transform.position.x, 7f, transform.position.z);
            GameObject stagecon = Instantiate(StageToSpawn[randomStageX], this.transform);
            stagecon.transform.position = newPosition;
            
            stagecon.name = "LineforStg";
            stagecon.SetActive(true);

        }
        spawn();
    }
    void UpdateNumberOfEnemy()
    {
        // Cập nhật numberOfEnemy bằng cách đếm số lượng đối tượng "Enemy" hiện có
        numberOfEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        maxNumberOfEnemy = GameObject.Find("GameControl").GetComponent<GameControl>().numberEnemy;
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("EnemyHolder");
    }
    void countPart()
    {
        if(count > 0 && numberOfEnemy == 0) 
        {
            count = 0;
            Destroy(this.gameObject);
        }
    }
    IEnumerator waitsec(float sec)
    {
        yield return new WaitForSeconds(sec);

        
    }

    private void Update()
    {
        countPart();
        UpdateNumberOfEnemy();

    }
    private void spawn()
    {
        if (count == 0) 
        { 
            UpdateNumberOfEnemy();
            /*if (numberOfEnemy == 0)
            { }*/
                
                //int pick = Random.Range(0, EnemyToSpawn.Length);
                int n = Random.Range(maxNumberOfEnemy - 2, maxNumberOfEnemy);


            float randomValueY = 13;
            float randomValueX = -3;

            for (int i = 0; i < n; i++)
                {
                
                if (randomCheck == true)
                {
                    int pick = Random.Range(0, EnemyToSpawn.Length);
                    if (EnemyToSpawn[pick].name[0] == '$') { n = n - 4; }
                    randomValueY = Random.Range(13, 16);
                    randomValueX = Random.Range(-3, 3);
                    //float fixedSpawn = randomValueX + (9 / n) * i;
                    Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0); // Ví dụ: Sinh ra tại vị trí (0, 0, 0)
                    Instantiate(EnemyToSpawn[pick], spawnPosition, Quaternion.identity);
                }

                if (randomCheck == false) 
                {
                    int pick = Random.Range(0, EnemyToSpawn.Length);
                    if (EnemyToSpawn[pick].name[0] == '$') { n = n - 4; }
                    randomValueY = randomValueY +0.75f;
                    randomValueX = -3;
                    //float fixedSpawn = randomValueX + (9 / n) * i;
                    Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0); // Ví dụ: Sinh ra tại vị trí (0, 0, 0)
                    Instantiate(EnemyToSpawn[pick], spawnPosition, Quaternion.identity);


                }

                

                // Sau khi sinh ra một đối tượng mới, cập nhật lại numberOfEnemy
                UpdateNumberOfEnemy();
                
                }
            
            count++;
        }


    }


}
