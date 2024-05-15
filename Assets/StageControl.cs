using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageControl : MonoBehaviour
{
    [SerializeField] bool randomCheck;
    [SerializeReference] bool moreEnemyType;
    [SerializeField] public int numberOfLine;
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
            for(int i =0; i< 3; i++)
            {
                Vector3 newPosition = new Vector3(transform.position.x, 7f-i, transform.position.z);
                GameObject stagecon = Instantiate(StageToSpawn[randomStageX], this.transform);
                stagecon.transform.position = newPosition;
                stagecon.name = "LineforStg"+i;
                stagecon.SetActive(true);
            }
           
            
            

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
            float randomValueX = -2;
            int pick = Random.Range(0, EnemyToSpawn.Length);
            
            for (int i = 0; numberOfEnemy < n; i++)
                {
                
                if (randomCheck == true)
                {
                    if (EnemyToSpawn[pick].name[0] == '$') { n = n - 4; }
                    randomValueY = Random.Range(13, 16);
                    randomValueX = Random.Range(-3, 3);
                    //float fixedSpawn = randomValueX + (9 / n) * i;
                    Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0); // Ví dụ: Sinh ra tại vị trí (0, 0, 0)
                    Instantiate(EnemyToSpawn[pick], spawnPosition, Quaternion.identity);
                }

                if (randomCheck == false) 
                {
                    if (EnemyToSpawn[pick].name[0] == '$') { n = n - 4; }
                    randomValueY = randomValueY +1f;
                 
                    randomValueX = randomValueX +1f;
                    //float fixedSpawn = randomValueX + (9 / n) * i;
                    Vector3 spawnPosition = new Vector3(randomValueX, randomValueY, 0); // Ví dụ: Sinh ra tại vị trí (0, 0, 0)

                    Vector3 spawnPosition1 = new Vector3(randomValueX, randomValueY - 1, 0);

                    GameObject enAlreadySpawn = Instantiate(EnemyToSpawn[pick], spawnPosition, Quaternion.identity);
                    enAlreadySpawn.GetComponent<XPath>().NumberOfFollowLine = 0;
                    if (numberOfLine>0) { GameObject enAlreadySpawn1 = Instantiate(EnemyToSpawn[pick], spawnPosition1, Quaternion.identity);
                        enAlreadySpawn1.GetComponent<XPath>().NumberOfFollowLine = 1; }
                    if (numberOfLine > 1)
                    {
                        GameObject enAlreadySpawn2 = Instantiate(EnemyToSpawn[pick], spawnPosition1, Quaternion.identity);
                        enAlreadySpawn2.GetComponent<XPath>().NumberOfFollowLine = 2;
                    }

                }

                

                // Sau khi sinh ra một đối tượng mới, cập nhật lại numberOfEnemy
                UpdateNumberOfEnemy();
                
                }
            
            count++;
        }


    }


}
