using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [Header("Movement")]
    public Transform bombPos1;
    public Transform bombPos2;
    public float bomberSpeed;
    public bool bombOnBeach;

    // Use this for initialization
    void Start()
    {
        bombOnBeach = false;
    }

    // Update is called once per frame
    void Update()
    {
        LeftAndRightMovement();
    }

    #region Movement
    void LeftAndRightMovement()
    {
        if (bombOnBeach == false)
        {
            GoRight();

            if (transform.position == bombPos2.position)
            {
                bombOnBeach = true;
            }
        }

        if (bombOnBeach == true)
        {
            GoLeft();

            if (transform.position == bombPos1.position)
            {
                bombOnBeach = false;
            }
        }
    }

    void GoRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, bombPos2.position, bomberSpeed * Time.deltaTime);
    }

    void GoLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, bombPos1.position, bomberSpeed * Time.deltaTime);
    }
    #endregion
}
