﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIAgent : MonoBehaviour
{
    public Transform navTarget;

    private NavMeshAgent nav;

    private List<Tower> towers = new List<Tower>();


    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }

    void Update()
    {
        AttackTarget();
    }

    void OnTriggerEnter(Collider col)
    {
        Tower tower = col.GetComponent<Tower>();

        if (tower != null && tower.enabled == true) // If triggered gameobject has a Tower script and that Tower script is active
        {
            towers.Add(tower);
        }

        if (tower != null && tower.enabled == false)
        {
            tower = null;
        }
    }

    /*void OnTriggerExit(Collider col) // Not using this bit anyway
    {
        Tower tower = col.GetComponent<Tower>();

        if (tower != null)
        {
            towers.Remove(tower);
        }
    }*/

    #region Tower & Attack
    Tower GetClosestTower()
    {
        towers = RemoveAllNulls(towers);

        Tower closest = null;

        float minDistance = float.MaxValue;

        for (int i = 0; i < towers.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, towers[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = towers[i];
            }
        }
        return closest;
    }

    List<Tower> RemoveAllNulls(List<Tower> listWithNulls)
    {
        List<Tower> listWithoutNulls = new List<Tower>();

        foreach (Tower closest in listWithNulls)
        {
            if (closest != null)
            {
                listWithoutNulls.Add(closest);
            }
        }

        return listWithoutNulls;
    }

    void AttackTarget()
    {
        Tower closest = GetClosestTower();

        if (closest != null)
        {
            navTarget = closest.transform;
            nav.SetDestination(navTarget.position);
        }

        /*if (navTarget.transform.gameObject.activeSelf == false)
        {
            //Debug.Log("navTarget " + navTarget + " not Active");
            

            //Debug.Log("closest = " + closest);
        }*/
    }
    #endregion
}