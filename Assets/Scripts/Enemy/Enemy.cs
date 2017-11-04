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
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        
    }

    void Start()
    {
        
    }   

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            
        }

    }

    
}

