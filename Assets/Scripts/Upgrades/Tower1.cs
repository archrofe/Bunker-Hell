using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower1 : MonoBehaviour
{
    [Header("Attack & Enemies")]
    public Cannon cannon; // Reference to cannon inside tower
    public float attackRate = 0.5f; // Rate of attack in world units
    public float attackRadius = 5f; // Distance of attack in world units

    private float attackTimer = 0f; // Timer to count up to attackRate
    private List<Enemy> enemies = new List<Enemy>(); // List of enemies whithin radius

    [Header("Buttons")]
    public GameObject bunker1Button;
    public GameObject b1AttackRateButton;

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

    #region Triggers, Enemies, & Attack
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

    #region Buttons & Upgrades
    public void Bunker1ButtonFunction()
    {
        b1AttackRateButton.SetActive(true);
    }

    public void B1AttackRateButtonFunction()
    {
        attackRate = attackRate / 2;
        b1AttackRateButton.SetActive(false);
    }
    #endregion
}
