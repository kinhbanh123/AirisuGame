using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHeal : MonoBehaviour
{
    public Text hpText;

    void Update()
    {
        int hp = GameObject.Find("Character").GetComponent<Stats>().currentHp;
        hpText.text = "" + hp /10;
    }
}
