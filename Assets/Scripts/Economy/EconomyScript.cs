using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyScript : MonoBehaviour
{
    public static float timer;
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
    public float wave1Check = 1f;
    public float wave2Check = 2f;
    public float wave3Check = 3f;
    public float wave4Check = 4f;
    public float wave5Check = 5f;

    public static float BunkerCheck;

    void Start()
    {
        timer = 0f;
        moneys = 500f;

        enemyCount = 0;

        RandomBoat();

        BunkerCheck = 0f;
        Debug.Log("BunkerCheck = " + BunkerCheck);
    }

    void Update()
    {
        totalGold = Mathf.RoundToInt(moneys);

        moneys = moneys - (enemyCount) * Time.deltaTime;
        //Debug.Log("enemyCount = " + enemyCount);


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
            if (BunkerCheck == wave1Check)
            {
                RandomBoat();
                wave1Done = true;
            }
        }
        // To Start Wave 3
        if (wave2Done == false)
        {
            if (BunkerCheck == wave2Check)
            {
                RandomBoat();
                wave2Done = true;
            }
        }
        // To Start Wave 4
        if (wave3Done == false)
        {
            if (BunkerCheck == wave3Check)
            {
                RandomBoat();
                wave3Done = true;
            }
        }
        // To Start Wave 5
        if (wave4Done == false)
        {
            if (BunkerCheck == wave4Check)
            {
                RandomBoat();
                wave4Done = true;
            }
        }
        // To Start Wave 6
        if (wave5Done == false)
        {
            if (BunkerCheck == wave5Check)
            {
                RandomBoat();
                wave5Done = true;
            }
        }
    }
    #endregion
}
