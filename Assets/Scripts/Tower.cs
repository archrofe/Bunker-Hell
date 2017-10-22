using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRate = 0.25f;
    public float attackRadius = 5f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Tower attackRate = " + attackRate);
        Debug.Log("Tower attackRadius = " + attackRadius);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
