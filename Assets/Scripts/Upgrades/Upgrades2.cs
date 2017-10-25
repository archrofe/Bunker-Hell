using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades2 : MonoBehaviour
{
    public GameObject bunker1Button;
    public GameObject b1AttackRateButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bunker1ButtonFunction()
    {
        b1AttackRateButton.SetActive(true);
    }
}
