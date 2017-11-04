using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerRandomStart : MonoBehaviour
{
    public GameObject[] bunkerChoice = null;
    public GameObject[] cannonChoice = null;

    public bool randomStart;
    public int randomChoice;
    
    // Use this for initialization
    void Start()
    {
        randomStart = false;

        if (randomStart == false)
        {
            randomChoice = Random.Range(0,bunkerChoice.Length);

            bunkerChoice[randomChoice].GetComponent<Tower>().enabled = true;
            cannonChoice[randomChoice].SetActive(true);

            randomStart = true;

            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
