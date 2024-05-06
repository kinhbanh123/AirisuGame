using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHeal : MonoBehaviour
{
    [SerializeField] GameObject[] hpIcon;
    private void Start()
    {
        for (int i = 0; i < hpIcon.Length; i++) {   hpIcon[i].SetActive(false);  }
    }
    void Update()
    {
        int hp = GameObject.Find("Character").GetComponent<Stats>().currentHp;
        if(hp == 30) { for (int i = 0; i < hpIcon.Length; i++) { if (i < 3) { hpIcon[i].SetActive(true); } else { hpIcon[i].SetActive(false); } } }
        if (hp == 20) { for (int i = 0; i < hpIcon.Length; i++) { if (i<2) { hpIcon[i].SetActive(true); } else { hpIcon[i].SetActive(false); } } }
        if (hp == 10) { for (int i = 0; i < hpIcon.Length; i++) { if (i < 1) { hpIcon[i].SetActive(true); } else { hpIcon[i].SetActive(false); } } }
    }
}
