using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIAgent2 : MonoBehaviour
{
    public Transform navTarget;

    private NavMeshAgent nav;

    private List<Tower1> towers = new List<Tower1>();


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
        Tower1 tower = col.GetComponent<Tower1>();

        if (tower != null)
        {
            towers.Add(tower);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Tower1 tower = col.GetComponent<Tower1>();

        if (tower != null)
        {
            towers.Remove(tower);
        }
    }

    Tower1 GetClosestTower()
    {
        towers = RemoveAllNulls(towers);

        Tower1 closest = null;

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

    List<Tower1> RemoveAllNulls(List<Tower1> listWithNulls)
    {
        List<Tower1> listWithoutNulls = new List<Tower1>();

        foreach (Tower1 closest in listWithNulls)
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
        Tower1 closest = GetClosestTower();

        if (closest != null)
        {
            navTarget = closest.transform;
            nav.SetDestination(navTarget.position);
        }

        if (closest = null)
        {
            closest = GetClosestTower();
        }
    }
}