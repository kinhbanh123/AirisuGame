using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{


    [SerializeField] int StageCheck;
    [SerializeField] public GameObject[] StageToSpawn;
    [SerializeField] public GameObject[] StageBoss;
    [SerializeField] public int StageNumber;
    [SerializeField] public int StageCount;
    [SerializeField] public int StageBossNumber;


    void Start()
    {
        StageBossNumber = 0;
        StageNumber = 1;
        // Khởi tạo numberOfEnemy ban đầu khi bắt đầu trò chơi
        InvokeRepeating("SpawnNewEnemy", 0f, 5f);
    }

    void makeThingHarder()
    {
        
        GameObject.Find("GameControl").GetComponent<GameControl>().numberChance = GameObject.Find("GameControl").GetComponent<GameControl>().numberChance + 1;
    }



    void SpawnNewEnemy()
    {
        StageCheck = GameObject.FindGameObjectsWithTag("Stage").Length;
        
        if (StageCheck == 0)
        {
            Debug.Log(StageNumber);
            if (StageNumber % 5 == 0) { Instantiate(StageBoss[StageBossNumber], Vector3.zero, Quaternion.identity); StageNumber++; StageBossNumber++; }
            else
            {
                int randomStage = Random.Range(0, StageToSpawn.Length);


                Instantiate(StageToSpawn[randomStage], Vector3.zero, Quaternion.identity);
                StageNumber++;
                makeThingHarder();
            }

        }
           
        
    }

}
