using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Bomb hit Ground");
            ContactPoint bombGround = other.contacts[0];
            GameObject clone;
            clone = Instantiate(explosion, bombGround.point, Quaternion.identity);
            Destroy(gameObject);
            EconomyScript.moneys = 40000f;
        }
    }
}
