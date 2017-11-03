using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
    public static float health = 100f; // Enemy's health which starts at 100
    public int enemyPoints = 1000;

    public Text gold;

    public void DealDamage(float damage)
    {
        health -= damage;       

        if (health <= 0)
        {
            KillCounter.killCount = KillCounter.killCount + 1;
            Debug.Log("Enemy Killed.");

            EconomyScript.moneys = EconomyScript.moneys + enemyPoints;
            Debug.Log("Moneys + 1000");

            Destroy(gameObject);
        }
    }
    void Awake()
    {
        
        
    }
    // Use this for initialization
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            
            Destroy(other.transform.parent.gameObject);
        }
    }

    
}

