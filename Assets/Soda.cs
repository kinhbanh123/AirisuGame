using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : MonoBehaviour
{
    [SerializeField] int number;
    void Awake()
    {
        GameObject.Find("Character").GetComponent<PlayerInfo>().PlayerLevelUp(number);
    }
}
