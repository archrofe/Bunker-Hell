using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    
    public float health = 100f; // Enemy's health which starts at 100
    public int money;
    

    public Text gold;

    public void DealDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {            
            
            Gold();
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

    void Gold()
    {
        money = money + 100;
        gold.text = money.ToString();
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

