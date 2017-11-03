using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public static int killCount;

    // Use this for initialization
    void Start()
    {
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("killCount = " + killCount);
    }
}
