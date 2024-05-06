using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WepConfig : MonoBehaviour
{
    [SerializeField] int typeWep;
    [SerializeField] int LevelRN;
    [SerializeField] int oldLevel;
    [SerializeField] GameObject[] LevelWep;
    [SerializeField] GameObject[] fixedLevelWep;
    void Start()
    {
        LevelWep[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }
    void checkLevel()
    {
        
        LevelRN = GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerLevel[typeWep];
        if (LevelRN != oldLevel)
        {
            if (LevelRN == 2) { LevelWep[1].SetActive(true); LevelWep[0].GetComponent<Shooting>().shootTimer = 0f; }
            if (LevelRN == 3) { LevelWep[2].SetActive(true); LevelWep[0].GetComponent<Shooting>().shootTimer = 0f; fixedLevelWep[0].GetComponent<Shooting>().shootTimer = 0f; fixedLevelWep[1].GetComponent<Shooting>().shootTimer = 0f; }
            oldLevel = LevelRN;
        }

        
    }
}
