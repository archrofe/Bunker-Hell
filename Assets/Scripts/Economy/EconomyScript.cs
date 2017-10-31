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


    // Use this for initialization
    void Start()
    {
        timer = 0f;
        moneys = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        totalGold = Mathf.RoundToInt(moneys);

        moneys = moneys + 5 * Time.deltaTime;

        timer = timer + 1 * Time.deltaTime;

        SetTimer();
        SetGold();
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
