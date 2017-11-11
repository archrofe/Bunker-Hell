using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 100; // Damage dealt to whatever gets hit

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Collider>().enabled == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Enemy e = col.GetComponent<Enemy>();

        if (e != null)
        {
            e.DealDamage(damage);
        }
    }
}
