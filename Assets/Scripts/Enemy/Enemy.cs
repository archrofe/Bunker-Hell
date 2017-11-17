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

        /*if (health <= 0)
        {
            //EconomyScript.moneys = EconomyScript.moneys + killPoints;
            EconomyScript.enemyCount = EconomyScript.enemyCount - 1;
            Destroy(gameObject);
        }*/
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
            Lose.loseScore = Lose.loseScore -1;
            Debug.Log("loseScore = " + Lose.loseScore);
            other.transform.parent.gameObject.SetActive(false);
            other.transform.parent.gameObject.GetComponent<Tower>().enabled = false;
            other.transform.parent.gameObject.GetComponent<Collider>().enabled = false;

            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            if (health <= other.gameObject.GetComponent<Explosion>().damage) // If Enemy hit by Explosion, check if Health is less than Explosion's Damage.
            {
                EconomyScript.enemyCount = EconomyScript.enemyCount - 1;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if (health <= other.gameObject.GetComponent<Projectile>().damage) // If Enemy hit by Bullet, check if Health is less than Bullet's Damage.
            {
                EconomyScript.moneys = EconomyScript.moneys + killPoints;
                EconomyScript.enemyCount = EconomyScript.enemyCount - 1;
                Destroy(gameObject);
            }
        }
    }    
}

