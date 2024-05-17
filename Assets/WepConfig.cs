using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WepConfig : MonoBehaviour
{
    [SerializeField] int typeWep;
    [SerializeField] int LevelRN0;
    [SerializeField] int LevelRN1;
    [SerializeField] int oldLevel0;
    [SerializeField] int oldLevel1;
    [SerializeField] GameObject[] LevelWep;
    [SerializeField] GameObject[] fixedLevelWep;
    [SerializeField] public float bulletSpeed;
    void Start()
    {
         if (typeWep == 0) 
        { 
        LevelWep[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }
    void checkLevel()
    {
        
        
        if (typeWep == 0) 
        { 
            LevelRN0 = GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerLevel[typeWep];
        if (LevelRN0 != oldLevel0)
        {
            if (LevelRN0 == 2) { LevelWep[1].SetActive(true); LevelWep[0].GetComponent<Shooting>().shootTimer = 0f; }
            if (LevelRN0 == 3) { LevelWep[2].SetActive(true); LevelWep[0].GetComponent<Shooting>().shootTimer = 0f; fixedLevelWep[0].GetComponent<Shooting>().shootTimer = 0f; fixedLevelWep[1].GetComponent<Shooting>().shootTimer = 0f; }
            oldLevel0 = LevelRN0;
        }
        }
        if (typeWep ==1) 
        { 
            LevelRN1 = GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerLevel[typeWep];
            if (LevelRN1 != oldLevel1)
        {
            if (LevelRN1 == 1) { Debug.Log("Da active 1 "); LevelWep[0].SetActive(true); LevelWep[0].GetComponent<Shooting>().shootTimer = 0f; LevelWep[1].SetActive(true); LevelWep[1].GetComponent<Shooting>().shootTimer = 0f; }
            if (LevelRN1 == 2) { LevelWep[2].SetActive(true); LevelWep[2].GetComponent<Shooting>().shootTimer = 0f; LevelWep[3].SetActive(true); LevelWep[3].GetComponent<Shooting>().shootTimer = 0f; }
            if (LevelRN1 == 3) { LevelWep[4].SetActive(true); LevelWep[4].GetComponent<Shooting>().shootTimer = 0f; LevelWep[5].SetActive(true); LevelWep[5].GetComponent<Shooting>().shootTimer = 0f; }
            oldLevel1 = LevelRN1;
        }
            
        }


    }
}
