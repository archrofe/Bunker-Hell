using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Menu Buttons")]
    public GameObject bunkerUI;
    public GameObject bunkerActivateButton;
    public GameObject bunkerActivateMenu;
    public float activateCost = 150f;
    public GameObject bunkerStatsMenu;
    public GameObject bunkerUpgradeMenu;
    public bool bunkerIsActive;
    public int upgradeLimit;

    [Header("Activate Buttons")]
    public GameObject yesActivateButton;
    public GameObject noActivateButton;

    [Header("Class Cannon/Gun GameObjects")]
    public GameObject bunkerGameObject;
    public GameObject bunkerCannon;

    [Header("Damage")]
    public int damageStat;
    public Text damageText;
    public int damageTechLevel;
    public float upgradeCost = 50f;
    public float boostTime = 5f;
    public bool boostOnBool;
    public int tempTechLevel;
    public int tempStat;
    public float boostCost = 100f;

    [Header("Fire Rate")]
    public int fireTechLevel;
    public Text fireText;
    public int fireStat;
    public float[] fireRateArray = null;
    public Tower bunkerTowerScript;

    [Header("Range")]
    public int rangeStat;
    public Text rangeText;
    public int rangeTechLevel;

    void Start()
    {
        bunkerTowerScript = bunkerGameObject.GetComponent<Tower>();

        bunkerIsActive = false;

        upgradeLimit = 5;

        damageStat = 50;
        fireStat = 50;
        rangeStat = 50;

        damageTechLevel = 3;
        fireTechLevel = 3;
        rangeTechLevel = 3;

        boostOnBool = false;

        StatUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        BunkerIsAliveCheck();
    }

    #region Bunker UI Activate
    public void BunkerIsAliveCheck() // If Bunker is Alive, then Bunker UI should be Active
    {
        if (bunkerGameObject == null || bunkerGameObject.activeSelf == false)
        {
            bunkerUI.SetActive(false);
        }

        if (bunkerCannon.activeSelf == true) // this is mostly for BunkerRandomStart script
        {
            bunkerIsActive = true;
            bunkerActivateButton.SetActive(false);
            bunkerActivateMenu.SetActive(false);

            bunkerStatsMenu.SetActive(true);
            bunkerUpgradeMenu.SetActive(true);
        }
    }

    public void BunkerActivateFunction() // ACTIVATE BUTTON: Turns Activate Menu ON
    {
        bunkerActivateMenu.SetActive(true);
    }

    public void NoActivateFunction() // NO BUTTON: Turns Activate Menu OFF
    {
        bunkerActivateMenu.SetActive(false);
    }

    public void YesActivateFunction() // Turns on STATS
    {
        if (activateCost <= EconomyScript.moneys)
        {
            bunkerActivateButton.SetActive(false);
            bunkerActivateMenu.SetActive(false);

            Lose.loseScore++;
            Debug.Log("bluh" + Lose.loseScore);

            bunkerStatsMenu.SetActive(true);
            bunkerCannon.SetActive(true);
            bunkerUpgradeMenu.SetActive(true);

            bunkerIsActive = true;
            bunkerGameObject.GetComponent<Tower>().enabled = true; // Need to Activate Tower script
            EconomyScript.moneys = EconomyScript.moneys - activateCost;
        }
    }
    #endregion

    #region Upgrades
    public void StatUpdate()
    {
        damageText.text = "Damage = " + damageStat.ToString();
        fireText.text = "Fire Rate = " + fireStat.ToString();
        rangeText.text = "Range = " + rangeStat.ToString();
    }

    public void DamageUpgradeButton()
    {
        if (upgradeCost <= EconomyScript.moneys && (damageTechLevel + 1 != 7) && (rangeTechLevel - 1 != -1) && boostOnBool == false)
        {
            damageTechLevel = damageTechLevel + 1; // called in Cannon script
            damageStat = damageStat + 10;

            rangeTechLevel = rangeTechLevel - 1; // called in Cannon script
            rangeStat = rangeStat - 10;

            EconomyScript.moneys = EconomyScript.moneys - upgradeCost;

            DebugStatsCheck();
            return;
        }

        else
        {

        }
    }

    public void FireRateUpgradeButton()
    {
        if (upgradeCost <= EconomyScript.moneys && (fireTechLevel + 1 != 7) && (damageTechLevel - 1 != -1) && boostOnBool == false)
        {
            fireTechLevel = fireTechLevel + 1;
            bunkerTowerScript.attackRate = fireRateArray[fireTechLevel];
            fireStat = fireStat + 10;

            damageTechLevel = damageTechLevel - 1; // called in Cannon script
            damageStat = damageStat - 10;

            EconomyScript.moneys = EconomyScript.moneys - upgradeCost;

            DebugStatsCheck();
            return;
        }

        else
        {

        }
    }

    public void RangeUpgradeButton()
    {
        if (upgradeCost <= EconomyScript.moneys && (rangeTechLevel + 1 != 7) && (fireTechLevel - 1 != -1) && boostOnBool == false)
        {
            rangeTechLevel = rangeTechLevel + 1; // called in Cannon script
            rangeStat = rangeStat + 10;

            fireTechLevel = fireTechLevel - 1;
            bunkerTowerScript.attackRate = fireRateArray[fireTechLevel];
            fireStat = fireStat - 10;

            EconomyScript.moneys = EconomyScript.moneys - upgradeCost;

            DebugStatsCheck();
            return;
        }

        else
        {

        }
    }

    public void DebugStatsCheck()
    {
        StatUpdate();

        Debug.Log("damageTechLevel = " + damageTechLevel);
        Debug.Log("fireTechLevel = " + fireTechLevel);
        Debug.Log("rangeTechLevel = " + rangeTechLevel);
    }

    #endregion

    #region Boost Buttons
    public void DamageBoostButton()
    {
        if (boostOnBool == false && boostCost <= EconomyScript.moneys)
        {
            EconomyScript.moneys = EconomyScript.moneys - boostCost;
            StartCoroutine(DamageBoostDuration());
        }
    }

    IEnumerator DamageBoostDuration()
    {
        DamageBoostOn();
        boostOnBool = true;

        yield return new WaitForSeconds(boostTime);

        DamageBoostOff();
        boostOnBool = false;
    }

    public void DamageBoostOn()
    {
        tempTechLevel = damageTechLevel;

        damageTechLevel = 8;

        tempStat = damageStat;

        damageStat = 100;
        
        StatUpdate();
    }

    public void DamageBoostOff()
    {
        damageTechLevel = tempTechLevel;

        damageStat = tempStat;

        StatUpdate();
    }

    public void FireBoostButton()
    {
        if (boostOnBool == false && boostCost <= EconomyScript.moneys)
        {
            EconomyScript.moneys = EconomyScript.moneys - boostCost;
            StartCoroutine(FireBoostDuration());
        }
    }

    IEnumerator FireBoostDuration()
    {
        FireBoostOn();
        boostOnBool = true;

        yield return new WaitForSeconds(boostTime);

        FireBoostOff();
        boostOnBool = false;
    }

    public void FireBoostOn()
    {
        tempTechLevel = fireTechLevel;

        fireTechLevel = 8;

        bunkerTowerScript.attackRate = fireRateArray[fireTechLevel];

        tempStat = fireStat;

        fireStat = 100;

        StatUpdate();
    }

    public void FireBoostOff()
    {
        fireTechLevel = tempTechLevel;
        bunkerTowerScript.attackRate = fireRateArray[fireTechLevel];

        fireStat = tempStat;

        StatUpdate();
    }

    public void RangeBoostButton()
    {
        if (boostOnBool == false && boostCost <= EconomyScript.moneys)
        {
            EconomyScript.moneys = EconomyScript.moneys - boostCost;
            StartCoroutine(RangeBoostDuration());
        }
    }

    IEnumerator RangeBoostDuration()
    {
        RangeBoostOn();
        boostOnBool = true;

        yield return new WaitForSeconds(boostTime);

        RangeBoostOff();
        boostOnBool = false;
    }

    public void RangeBoostOn()
    {
        tempTechLevel = rangeTechLevel;

        rangeTechLevel = 8;

        tempStat = rangeStat;

        rangeStat = 100;

        StatUpdate();
    }

    public void RangeBoostOff()
    {
        rangeTechLevel = tempTechLevel;

        rangeStat = tempStat;

        StatUpdate();
    }    
    #endregion
}
