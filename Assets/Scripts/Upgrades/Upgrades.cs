using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("Menu & Class Buttons")]
    public GameObject bunkerActivateButton;
    public GameObject bunkerClassMenu;
    public GameObject bunkerUpgradeMenu;
    public bool bunkerIsActive;
    public GameObject shotgunClassButton;
    public GameObject sniperClassButton;
    public GameObject machineGunClassButton;

    [Header("Class Cannon/Gun GameObjects")]
    public GameObject bunkerGameObject;
    public GameObject shotgunCannon;
    public GameObject sniperCannon;
    public GameObject machineGunCannon;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Buttons & Upgrades
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
        bunkerGameObject.SetActive(true);
        shotgunCannon.SetActive(true);
        bunkerUpgradeMenu.SetActive(true);
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
