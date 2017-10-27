﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    public float damage = 50f; // Damage dealt to whatever gets hit
    public float speed = 50f; // Speed the projectile travels
    public Vector3 direction; // Direction the projectile travels
                              // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = direction.normalized * speed;
        gameObject.transform.position += velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        Enemy e = col.GetComponent<Enemy>();

        if (e != null)
        {
            e.DealDamage(damage);
            Destroy(gameObject);
        }

        if (col.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}

