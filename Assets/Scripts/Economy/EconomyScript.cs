using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyScript : MonoBehaviour
{

    public float timer;
    public Text theTime;
    public Text gold;
    public float moneys;
    public int totalGold;
    public static float enemyHealth;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        moneys = 0;

        enemyHealth = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        EarnedMoney();

        enemyHealth = Enemy.health;

        totalGold = Mathf.RoundToInt(moneys);

        moneys = moneys + 1 * Time.deltaTime;

        timer = timer + 1 * Time.deltaTime;

        SetTimer();
        SetGold();
    }

    void EarnedMoney()
    {
        if (enemyHealth == 0)
        {

            KillGold();
            Enemy.health = 100;
        }
    }

    void KillGold()
    {
        moneys = moneys + 100;
    }
    void SetGold()
    {
        gold.text = "Gold:" + totalGold.ToString();
    }

    void SetTimer()
    {
        theTime.text = "Timer:" + timer.ToString("0.0");
    }
}
