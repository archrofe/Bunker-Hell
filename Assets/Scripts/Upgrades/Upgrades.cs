using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Dropdown bunker1Dropdown;

    public GameObject bunker1;
    public GameObject bunker2;
    public GameObject bunker3;
    public GameObject bunker4;
    public GameObject bunker5;
    public GameObject bunker6;

    private Tower bunker1Tower;

    // Use this for initialization
    void Start()
    {
        bunker1Tower = bunker1.GetComponent<Tower>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeAttackRate()
    {

        
    }

    public void UpgradeAttackRadius()
    {
        
    }

    public void UpgradeDropdownChoices()
    {
        switch (bunker1Dropdown.captionText.text)
        {
            case "Attack Rate":
                UpgradeAttackRate();
                //Debug.Log("Bunker1 Attack Rate = " + bunker1Tower.attackRate);
                break;

            case "Attack Radius":
                UpgradeAttackRadius();
                break;
        }
    }
}
