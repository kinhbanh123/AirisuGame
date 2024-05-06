using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] int[] chanceDrop;
    [SerializeField] GameObject[] dropItem;
    [SerializeField] int exp;
    public void CountAndDrop()
    {
        for (int i = 0; i < chanceDrop.Length; i++)
        {
            int random = Random.Range(0, 100);
            if (random < chanceDrop[i])
            {
                Instantiate(dropItem[i], transform.position, Quaternion.identity); 
            }

        }
    }
    public void PlusExp()
    {
        GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerExp = GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerExp + exp;
    }
}
