using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] GameObject EnemyControl;
    [SerializeField] public int numberEnemy;
    [SerializeField] public int numberChance;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void harder()
    {

        EnemyControl.GetComponent<SupriseThing>().chance = numberChance;
    }    


}
