using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Menu Buttons")]
    public GameObject bunkerUI;
    public GameObject bunkerActivateButton;
    public GameObject bunkerClassMenu;
    public GameObject bunkerUpgradeMenu;
    public bool bunkerIsActive;

    [Header("Other Bunker UI")]
    public GameObject otherBunkerUI1;
    public GameObject otherBunkerUI2;
    public GameObject otherBunkerUI3;
    public GameObject otherBunkerUI4;
    public GameObject otherBunkerUI5;

    [Header("Class Buttons")]
    public GameObject shotgunClassButton;
    public GameObject machineGunClassButton;
    public GameObject sniperClassButton;

    [Header("Class Cannon/Gun GameObjects")]
    public GameObject bunkerGameObject;
    public GameObject bunkerCannon;
    public bool bunkerIsShotgun;
    public bool bunkerIsMachineGun;
    public bool bunkerIsSniper;
    public bool bunkerTech2;
    public bool bunkerTech3;

    [Header("Variables")]
    public bool fireRateTech2;
    public bool fireRateTech3;
    public bool damageTech2;
    public bool damageTech3;
    public bool rangeTech2;
    public bool rangeTech3;
    public bool accuracyTech2;
    public bool accuracyTech3;

    [Header("Variables Buttons")]
    public GameObject fireRateButton;
    public GameObject damageButton;
    public GameObject rangeButton;
    public GameObject accuracyButton;

    [Header("Scripts")]
    private Tower bunkerTowerScript;



    // Use this for initialization
    void Start()
    {
        bunkerTowerScript = bunkerGameObject.GetComponent<Tower>();

        bunkerIsActive = false;
        bunkerIsShotgun = false;
        bunkerIsSniper = false;
        bunkerIsMachineGun = false;

        bunkerTech2 = false;
        bunkerTech3 = false;

        fireRateTech2 = false;
        fireRateTech3 = false;

        damageTech2 = false;
        damageTech3 = false;

        rangeTech2 = false;
        rangeTech3 = false;

        accuracyTech2 = false;
        accuracyTech3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        BunkerIsAliveCheck();
    }

    #region UI Activate & Classes Menu
    public void BunkerIsAliveCheck()
    {
        if (bunkerGameObject == null)
        {
            bunkerUI.SetActive(false);
        }
    }

    public void BunkerActivateFunction()
    {
        if(bunkerActivateButton.activeSelf == true && bunkerClassMenu.activeSelf == false)
        {
            bunkerActivateButton.SetActive(false);
            bunkerClassMenu.SetActive(true);
            return;
        }

        if (bunkerActivateButton.activeSelf == false && bunkerClassMenu.activeSelf == true)
        {
            bunkerActivateButton.SetActive(true);
            bunkerClassMenu.SetActive(false);
            return;
        }

        
    }

    public void BunkerClassesMenuFunction()
    {
        if (bunkerIsActive == false)
        {
            sniperClassButton.SetActive(true);
            machineGunClassButton.SetActive(true);
            shotgunClassButton.SetActive(true);
        }
        else
        {
            BunkerUpgradesMenuFunction();
        }
    }

    public void ShotgunButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerTowerScript.attackRate = 0.6f;

        bunkerIsShotgun = true;
    }

    public void SniperButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerTowerScript.attackRate = 0.8f;

        bunkerIsSniper = true;
    }

    public void MachineGunButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerTowerScript.attackRate = 0.4f;

        bunkerIsMachineGun = true;
    }
    #endregion

    #region UI Upgrades & Variables Menu
    public void BunkerUpgradesMenuFunction()
    {
        if (fireRateButton.activeSelf == true && damageButton.activeSelf == true && rangeButton.activeSelf == true /*&& accuracyButton.activeSelf == true*/)
        {
            fireRateButton.SetActive(false);
            damageButton.SetActive(false);
            rangeButton.SetActive(false);
            //accuracyButton.SetActive(false);

            otherBunkerUI1.SetActive(true);
            otherBunkerUI2.SetActive(true);
            otherBunkerUI3.SetActive(true);
            otherBunkerUI4.SetActive(true);
            otherBunkerUI5.SetActive(true);

            return;
        }

        if (fireRateButton.activeSelf == false && damageButton.activeSelf == false && rangeButton.activeSelf == false /*&& accuracyButton.activeSelf == false*/)
        {
            fireRateButton.SetActive(true);
            damageButton.SetActive(true);
            rangeButton.SetActive(true);
            //accuracyButton.SetActive(true);

            otherBunkerUI1.SetActive(false);
            otherBunkerUI2.SetActive(false);
            otherBunkerUI3.SetActive(false);
            otherBunkerUI4.SetActive(false);
            otherBunkerUI5.SetActive(false);

            return;
        }
    }

    public void AttackRateButtonFunction()
    {
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);
        //accuracyButton.SetActive(false);

        otherBunkerUI1.SetActive(true);
        otherBunkerUI2.SetActive(true);
        otherBunkerUI3.SetActive(true);
        otherBunkerUI4.SetActive(true);
        otherBunkerUI5.SetActive(true);

        if (fireRateTech2 == false)
        {
            bunkerTowerScript.attackRate = bunkerTowerScript.attackRate - 0.1f;
            fireRateTech2 = true;
            return;
        }

        if (fireRateTech2 == true && fireRateTech3 == false)
        {
            bunkerTowerScript.attackRate = bunkerTowerScript.attackRate - 0.1f;
            fireRateTech3 = true;
            return;
        }
    }

    public void DamageButtonFunction()
    {
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);
        //accuracyButton.SetActive(false);

        otherBunkerUI1.SetActive(true);
        otherBunkerUI2.SetActive(true);
        otherBunkerUI3.SetActive(true);
        otherBunkerUI4.SetActive(true);
        otherBunkerUI5.SetActive(true);

        if (damageTech2 == false)
        {
            damageTech2 = true;
            return;
        }

        if(damageTech2 == true && damageTech3 == false)
        {
            damageTech3 = true;
            return;
        }
    }

    public void RangeButtonFunction()
    {
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);
        //accuracyButton.SetActive(false);

        otherBunkerUI1.SetActive(true);
        otherBunkerUI2.SetActive(true);
        otherBunkerUI3.SetActive(true);
        otherBunkerUI4.SetActive(true);
        otherBunkerUI5.SetActive(true);

        if (rangeTech2 == false)
        {
            rangeTech2 = true;
            return;
        }

        if (rangeTech2 == true && rangeTech3 == false)
        {
            rangeTech3 = true;
            return;
        }
    }

    public void AccuracyButtonFunction()
    {
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);
        //accuracyButton.SetActive(false);

        otherBunkerUI1.SetActive(true);
        otherBunkerUI2.SetActive(true);
        otherBunkerUI3.SetActive(true);
        otherBunkerUI4.SetActive(true);
        otherBunkerUI5.SetActive(true);

        if (accuracyTech2 == false)
        {
            accuracyTech2 = true;
            return;
        }

        if (accuracyTech2 == true && accuracyTech3 == false)
        {
            accuracyTech3 = true;
            return;
        }
    }
    #endregion
}
