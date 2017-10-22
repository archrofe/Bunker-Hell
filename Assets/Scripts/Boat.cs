using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [Header("Movement")]
    public Transform boatPos1;
    public Transform boatPos2;
    public float boatSpeed;
    public bool boatOnBeach;

    // Use this for initialization
    void Start()
    {
        boatOnBeach = false;
    }

    // Update is called once per frame
    void Update()
    {
        LeftAndRightMovement();
    }

    #region Movement
    void LeftAndRightMovement()
    {
        if (boatOnBeach == false)
        {
            GoRight();

            if (transform.position == boatPos2.position)
            {
                boatOnBeach = true;
            }
        }

        if (boatOnBeach == true)
        {
            GoLeft();

            if (transform.position == boatPos1.position)
            {
                boatOnBeach = false;
            }
        }
    }

    void GoRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, boatPos2.position, boatSpeed * Time.deltaTime);
    }

    void GoLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, boatPos1.position, boatSpeed * Time.deltaTime);
    }
    #endregion
}
