using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] Animator animator;
    [SerializeField] public int[] PlayerLevel;
    [SerializeField] public float[] PlayerSpeedFire;
    [SerializeField] public GameObject[] TypeBullet;
    [SerializeField] public int PlayerExp;
    void Start()
    {
        
        PlayerSpeedFire[0] = 0.5f;
        TypeBullet[0].GetComponent<BulletFly>().bulletSpeed = 10f;
        PlayerLevel[0] = 1;

    }

    public float checkNameAndStat(string name)
    {
        if(name == "BL")
        {
            return PlayerSpeedFire[1];
        }
        else
        {
            return PlayerSpeedFire[0];
        }

    }




    public void PlayerLevelUp(int pick)
    {
        if (PlayerLevel[pick] < 4) 
        {
            PlayerLevel[pick]++;
            if(PlayerLevel[pick] == 4) { PlayerSpeedFire[pick] = PlayerSpeedFire[pick] / 2f; }
            TypeBullet[pick].GetComponent<BulletFly>().bulletSpeed = TypeBullet[pick].GetComponent<BulletFly>().bulletSpeed * 3;
        }
        else
        {
            Debug.Log(PlayerLevel[0]);
        }
        
       StartCoroutine(action());
    }





    IEnumerator action()
    {
        effect.SetActive(true);
        animator.SetBool("Roll", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("Roll", false);
        effect.SetActive(false);
    }
}
