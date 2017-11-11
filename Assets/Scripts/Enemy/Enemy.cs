using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Enemy's health which starts at 100

    public float killPoints = 100;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EconomyScript.moneys = EconomyScript.moneys + killPoints;
            EconomyScript.enemyCount = EconomyScript.enemyCount - 1;
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        
    }

    void Start()
    {
        EconomyScript.enemyCount = EconomyScript.enemyCount + 1;
    }   

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            //Destroy(other.transform.parent.gameObject);
            Lose.loseScore = Lose.loseScore -1;
            Debug.Log("Lose Score = " + Lose.loseScore);
            other.transform.parent.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            EconomyScript.moneys = EconomyScript.moneys + killPoints;
            EconomyScript.enemyCount = EconomyScript.enemyCount - 1;
            Destroy(gameObject);
            Debug.Log("Killed by Bomb");
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            
        }

    }    
}

