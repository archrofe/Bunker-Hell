using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float health = 100f; // Enemie's health which starts at 100

    public void DealDamage(float damage)
    {
        float health = -damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

