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

    public int randomChoice;

    public static float enemyCount;

    [Header("Bools")]
    public bool wave1Done = false;
    public bool wave2Done = false;
    public bool wave3Done = false;
    public bool wave4Done = false;
    public bool wave5Done = false;

    [Header("Waves")]
    public float wave1Time = 10f;
    public float wave2Time = 20f;
    public float wave3Time = 30f;
    public float wave4Time = 40f;
    public float wave5Time = 50f;

    void Start()
    {
        timer = 0f;
        moneys = 1500f;

        enemyCount = 0;

        RandomBoat();
    }

    void Update()
    {
        totalGold = Mathf.RoundToInt(moneys);

        moneys = moneys - (enemyCount/20) * Time.deltaTime;
        Debug.Log("enemyCount = " + enemyCount);


        if (moneys <= 0)
        {
            moneys = 0;
        }

        timer = timer + 1 * Time.deltaTime;

        SetTimer();
        SetGold();

        Waves();
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
        randomChoice = Random.Range(0, boatChoice.Length);

        //Debug.Log("randomChoice + " + randomChoice);

        for (int i = randomChoice; i < boatChoice.Length; i = Random.Range(0, 6))
        {
            //Debug.Log("i = " + i);

            if (boatChoice[i].activeSelf == false)
            {
                boatChoice[i].SetActive(true);
                //Debug.Log("Boat activated = " + i);
                return;
            }
        }
    }

        #region Waves
        void Waves()
    {
        // To Start Wave 2
        if (wave1Done == false)
        {
            if (timer >= wave1Time)
            {
                RandomBoat();
                wave1Done = true;
            }
        }
        // To Start Wave 3
        if (wave2Done == false)
        {
            if (timer >= wave2Time)
            {
                RandomBoat();
                wave2Done = true;
            }
        }
        // To Start Wave 4
        if (wave3Done == false)
        {
            if (timer >= wave3Time)
            {
                RandomBoat();
                wave3Done = true;
            }
        }
        // To Start Wave 5
        if (wave4Done == false)
        {
            if (timer >= wave4Time)
            {
                RandomBoat();
                wave4Done = true;
            }
        }
        // To Start Wave 6
        if (wave5Done == false)
        {
            if (timer >= wave5Time)
            {
                RandomBoat();
                wave5Done = true;
            }
        }
    }
    #endregion
}
