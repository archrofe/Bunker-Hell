﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public Transform barrel; // Reference to Barrel where bullet will be shot from

    public GameObject bunkerUI;

    public GameObject bulletPrefab;

    public Light shot;

    public float[] damageArray = null;
    public float[] rangeArray = null;

    void Start()
    {
        shot.enabled = false;
    }

    void Update()
    {

    }

    public void Fire(Enemy targetEnemy)
    {
        if (bunkerUI.GetComponent<Upgrades>().bunkerIsActive == true) // Check UPGRADES script bool that Bunker has been Activated, should not Fire if not Activated
        {
            Vector3 targetPos = targetEnemy.transform.position;
            Vector3 barrelPos = barrel.transform.position;
            Quaternion barrelRot = barrel.rotation;
            Vector3 fireDirection = targetPos - barrelPos;

            transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

            GameObject clone = Instantiate(bulletPrefab, barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            StartCoroutine(Shot());

            DestroyOnLifeTime q = clone.GetComponent<DestroyOnLifeTime>();

            #region Damage & Range Upgrades
            p.damage = damageArray[bunkerUI.GetComponent<Upgrades>().damageTechLevel];
            q.lifeTime = rangeArray[bunkerUI.GetComponent<Upgrades>().rangeTechLevel];
            #endregion

            if (bunkerUI.GetComponent<Upgrades>().boostOnBool == true)
            {
                clone.GetComponent<TrailRenderer>().enabled = true;
            }

            p.direction = fireDirection;

            return;
        }
    }

    IEnumerator Shot()
    {
        shot.enabled = true;

        yield return new WaitForSeconds(.1f);

        shot.enabled = false;
    }
}

