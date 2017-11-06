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

    public GameObject[] boatChoice = null;

    public bool randomStart;
    public int randomChoice;

    [Header("Bools")]
    public bool wave1Done = false;
    public bool wave2Done = false;
    public bool wave3Done = false;
    public bool wave4Done = false;
    public bool wave5Done = false;

    [Header("Waves")]
    public float wave1Time = 10f;

    void Start()
    {
        timer = 0f;
        moneys = 1500f;

        RandomBoat();
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

    void RandomBoat()
    {
        randomStart = false;

        if (randomStart == false)
        {
            randomChoice = Random.Range(0, boatChoice.Length);

            boatChoice[randomChoice].SetActive(true);

            randomStart = true;

            return;
        }
    }

    #region Waves
    void Waves()
    {
        // to start wave 2
        if (wave1Done == false)
        {
            if (timer >= wave1Time)
            {
                boatChoice[randomChoice].SetActive(true);

                wave1Done = true;
            }
        }
    }
    #endregion
}
