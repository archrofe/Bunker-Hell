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
    public bool damageTech2;
    public bool damageTech3;
    public bool rangeTech2;
    public bool rangeTech3;

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

        damageTech2 = false;
        damageTech3 = false;

        rangeTech2 = false;
        rangeTech3 = false;
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
        bunkerActivateButton.SetActive(false);
        bunkerClassMenu.SetActive(true);
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

        bunkerIsShotgun = true;
    }

    public void SniperButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerIsSniper = true;
    }

    public void MachineGunButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerIsMachineGun = true;
    }
    #endregion

    #region UI Upgrades & Variables Menu
    public void BunkerUpgradesMenuFunction()
    {
        if (fireRateButton.activeSelf == true && damageButton.activeSelf == true && rangeButton.activeSelf == true)
        {
            fireRateButton.SetActive(false);
            damageButton.SetActive(false);
            rangeButton.SetActive(false);
            return;
        }

        if (fireRateButton.activeSelf == false && damageButton.activeSelf == false && rangeButton.activeSelf == false)
        {
            fireRateButton.SetActive(true);
            damageButton.SetActive(true);
            rangeButton.SetActive(true);
            return;
        }
    }

    public void AttackRateButtonFunction()
    {
        bunkerTowerScript.attackRate = bunkerTowerScript.attackRate * 0.75f;
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);
    }

    public void DamageButtonFunction()
    {
        fireRateButton.SetActive(false);
        damageButton.SetActive(false);
        rangeButton.SetActive(false);

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
    #endregion
}
