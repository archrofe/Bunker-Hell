using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyScript : MonoBehaviour
{
    public float timer;
    public Text theTime;
    public Text gold;
    public static float moneys;
    public int totalGold;

    void Start()
    {
        timer = 0f;
        moneys = 1500f;
    }

    void Update()
    {
        totalGold = Mathf.RoundToInt(moneys);

        moneys = moneys - 25 * Time.deltaTime;

        if (moneys <= 0)
        {
            moneys = 0;
        }

        timer = timer + 1 * Time.deltaTime;

        SetTimer();
        SetGold();
    }

    void SetGold()
    {
        gold.text = "Gold: " + totalGold.ToString();
    }

    void SetTimer()
    {
        theTime.text = "Timer: " + timer.ToString("0.0");
    }
}
