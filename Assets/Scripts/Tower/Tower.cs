using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public Cannon cannon; // Reference to Cannon Script inside Tower
    public float attackRate = 0.5f;
    public float attackRadius = 5f; // Distance of attack in world units

    private float attackTimer = 0f; // Timer to count up to attackRate
    private List<Enemy> enemies = new List<Enemy>(); // List of enemies whithin radius

    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {


        attackTimer = attackTimer + Time.deltaTime;

        if (attackTimer >= attackRate)
        {
            Attack();
            attackTimer = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Enemy e = col.GetComponent<Enemy>();

        if (e != null)
        {
            enemies.Add(e);
        }
    }

    void OnTriggerExit(Collider col)
    {
        Enemy e = col.GetComponent<Enemy>();

        if (e != null)
        {
            enemies.Remove(e);
        }
    }

    #region Enemy & Attack
    Enemy GetClosestEnemy()
    {
        enemies = RemoveAllNulls(enemies);

        Enemy closest = null;

        float minDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemies[i];
            }
        }
        return closest;
    }

    List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
    {
        List<Enemy> listWithoutNulls = new List<Enemy>();

        foreach (Enemy closest in listWithNulls)
        {
            if (closest != null)
            {
                listWithoutNulls.Add(closest);
            }
        }

        return listWithoutNulls;
    }

    void Attack()
    {
        Enemy closest = GetClosestEnemy();

        if (closest != null)
        {
            cannon.Fire(closest);
        }
    }
    #endregion
}
