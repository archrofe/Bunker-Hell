using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Menu & Class Buttons")]
    public GameObject bunkerUI;
    public GameObject bunkerActivateButton;
    public GameObject bunkerClassMenu;
    public GameObject bunkerUpgradeMenu;
    public bool bunkerIsActive;
    public GameObject shotgunClassButton;
    public GameObject machineGunClassButton;
    public GameObject sniperClassButton;

    [Header("Class Cannon/Gun GameObjects")]
    public GameObject bunkerGameObject;
    public GameObject bunkerCannon;
    public static bool bunkerIsShotgun;
    public static bool bunkerIsMachineGun;
    public static bool bunkerIsSniper;

    [Header("Fire Rate Variable")]
    public float shotgunFireRate = 1f;
    public float sniperFireRate = 2f;
    public float machineGunFireRate = 0.5f;

    [Header("Variables Buttons")]
    public GameObject fireRateButton;
    public GameObject accuracyButton;
    public GameObject damageButton;
    public GameObject rangeButton;

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
    }

    // Update is called once per frame
    void Update()
    {
        BunkerIsAliveCheck();
    }

    #region Buttons & Upgrades
    public void BunkerIsAliveCheck()
    {
        if(bunkerGameObject == null)
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

        bunkerTowerScript.attackRate = shotgunFireRate;

        bunkerIsShotgun = true;
    }

    public void SniperButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerTowerScript.attackRate = sniperFireRate;

        bunkerIsSniper = true;
    }

    public void MachineGunButtonFunction()
    {
        bunkerClassMenu.SetActive(false);
        bunkerUpgradeMenu.SetActive(true);

        bunkerCannon.SetActive(true);

        bunkerTowerScript.attackRate = machineGunFireRate;

        bunkerIsMachineGun = true;
    }

    public void BunkerUpgradesMenuFunction()
    {
        fireRateButton.SetActive(true);
    }

    public void AttackRateButtonFunction()
    {
        bunkerTowerScript.attackRate = bunkerTowerScript.attackRate / 2f;
        fireRateButton.SetActive(false);
    }
    #endregion
}
