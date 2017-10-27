using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public Transform barrel; // Reference to Barrel where bullet will be shot from

    public bool bunkerIsSniper;
    public bool bunkerIsShotgun;
    public bool bunkerIsMachineGun;

    public GameObject[] bulletTypes = null;

    void Start()
    {
        bunkerIsSniper = Upgrades.bunkerIsSniper;
        bunkerIsShotgun = Upgrades.bunkerIsShotgun;
        bunkerIsMachineGun = Upgrades.bunkerIsMachineGun;
    }

    void Update()
    {

    }

    public void Fire(Enemy targetEnemy)
    {
        Vector3 targetPos = targetEnemy.transform.position;
        Vector3 barrelPos = barrel.transform.position;
        Quaternion barrelRot = barrel.rotation;
        Vector3 fireDirection = targetPos - barrelPos;

        transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

        if(bunkerIsSniper == true)
        {
            GameObject clone = Instantiate(bulletTypes[1], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            p.direction = fireDirection;

            return;
        }

        if (bunkerIsMachineGun == true)
        {
            GameObject clone = Instantiate(bulletTypes[0], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            p.direction = fireDirection;

            return;
        }

        if (bunkerIsShotgun == true)
        {
            GameObject clone = Instantiate(bulletTypes[2], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            p.direction = fireDirection;

            return;
        }
    }
}

