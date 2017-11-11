using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [Header("Movement")]
    public Transform bombPos1;
    public Transform bombPos2;
    public float bomberSpeed;
    public bool bomberArrived;

    [Header("Bomber")]
    public GameObject bomberButton;
    public float bomberCost = 100;
    public bool bomberMoving;

    // Use this for initialization
    void Start()
    {
        bomberMoving = false;
        bomberArrived = true;
    }

    // Update is called once per frame
    void Update()
    {
        LeftMovement();
        BomberButtonActivateCheck();
    }

    #region Movement
    void LeftMovement()
    {
        if (bomberArrived == false)
        {
            GoLeft();
            //Debug.Log("bomberArrived = " + bomberArrived);
        }

        if (bomberArrived == true)
        {
            //Debug.Log("bomberArrived = " + bomberArrived);
            transform.position = new Vector3(bombPos1.position.x, bombPos1.position.y, bombPos1.position.z);
            bomberMoving = false;
            return;
        }

    }

    void GoLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, bombPos2.position, bomberSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BomberPos2"))
        {
            bomberArrived = true;
            //Debug.Log("bomberArrived = " + bomberArrived);
        }
    }

    #endregion

    #region Bomber Button stuff
    public void BomberButtonActivateCheck()
    {
        if (bomberCost <= EconomyScript.moneys) // Button only appears if you have enough money to use it
        {
            bomberButton.SetActive(true);
        }
    }

    public void BomberButton()
    {
        if (bomberMoving == false) // So you have to wait for Bomber to complete its run before using again
        {
            EconomyScript.moneys = EconomyScript.moneys - bomberCost; // Cost
            bomberButton.SetActive(false); // 
            bomberMoving = true;
            bomberArrived = false; // This should tell Bomber to start moving
            return;
        }
    }
    #endregion
}
