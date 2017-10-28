using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public Transform barrel; // Reference to Barrel where bullet will be shot from

    public GameObject bunkerUI;

    public bool bunkerIsShotgun;
    public bool bunkerIsMachineGun;
    public bool bunkerIsSniper;

    public GameObject[] bulletTypes = null;

    // Testing for Offset below
    //public int offsetShotgun = 15;
    //public float shotgunDelay = 0.25f;

    void Start()
    {
        bunkerIsShotgun = bunkerUI.GetComponent<Upgrades>().bunkerIsShotgun;
        bunkerIsMachineGun = bunkerUI.GetComponent<Upgrades>().bunkerIsMachineGun;
        bunkerIsSniper = bunkerUI.GetComponent<Upgrades>().bunkerIsSniper;
    }

    void Update()
    {

    }

    #region Fire & Projectile Instance
    public void Fire(Enemy targetEnemy)
    {
        Vector3 targetPos = targetEnemy.transform.position;
        Vector3 barrelPos = barrel.transform.position;
        Quaternion barrelRot = barrel.rotation;
        Vector3 fireDirection = targetPos - barrelPos;

        // Testing Offset for Multiple Shotgun Bullets fired at once AND/OR Accuracy
        /*Vector3 targetPosPlus = new Vector3(targetEnemy.transform.position.x + offsetShotgun, targetEnemy.transform.position.y, targetEnemy.transform.position.z + offsetShotgun);
        Vector3 fireDirectionPlus = targetPosPlus - barrelPos;

        Vector3 targetPosMinus = new Vector3(targetEnemy.transform.position.x - offsetShotgun, targetEnemy.transform.position.y, targetEnemy.transform.position.z - offsetShotgun);
        Vector3 fireDirectionMinus = targetPosMinus - barrelPos;*/

        transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

        #region Shotgun & Upgrades
        if (bunkerIsShotgun == true)
        {
            GameObject clone = Instantiate(bulletTypes[2], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            DestroyOnLifeTime q = clone.GetComponent<DestroyOnLifeTime>();

            // Damage Upgrades
            if (bunkerUI.GetComponent<Upgrades>().damageTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == false)
                {
                    p.damage = p.damage * 2f;
                }

                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == true)
                {
                    p.damage = p.damage * 3f;
                }
            }

            // Range Upgrades
            if (bunkerUI.GetComponent<Upgrades>().rangeTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == false)
                {
                    q.lifeTime = q.lifeTime * 1.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == true)
                {
                    q.lifeTime = q.lifeTime * 2f;
                }
            }

            // Accuracy Upgrades
            if (bunkerUI.GetComponent<Upgrades>().accuracyTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == false)
                {
                    p.speed = p.speed * 2f;
                    q.lifeTime = q.lifeTime * 0.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == true)
                {
                    p.speed = p.speed * 3f;
                    q.lifeTime = q.lifeTime * 0.35f;
                }
            }

            p.direction = fireDirection;

            return;
        }
        #endregion

        #region Machine Gun & Upgrades
        if (bunkerIsMachineGun == true)
        {
            GameObject clone = Instantiate(bulletTypes[0], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            DestroyOnLifeTime q = clone.GetComponent<DestroyOnLifeTime>();

            // Damage Upgrades
            if (bunkerUI.GetComponent<Upgrades>().damageTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == false)
                {
                    p.damage = p.damage * 2f;
                }

                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == true)
                {
                    p.damage = p.damage * 3f;
                }
            }

            // Range Upgrades
            if (bunkerUI.GetComponent<Upgrades>().rangeTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == false)
                {
                    q.lifeTime = q.lifeTime * 1.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == true)
                {
                    q.lifeTime = q.lifeTime * 2f;
                }
            }

            // Accuracy Upgrades
            if (bunkerUI.GetComponent<Upgrades>().accuracyTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == false)
                {
                    p.speed = p.speed * 2f;
                    q.lifeTime = q.lifeTime * 0.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == true)
                {
                    p.speed = p.speed * 3f;
                    q.lifeTime = q.lifeTime * 0.35f;
                }
            }

            p.direction = fireDirection;

            return;
        }
        #endregion

        #region Sniper & Upgrades
        if (bunkerIsSniper == true)
        {
            GameObject clone = Instantiate(bulletTypes[1], barrelPos, barrelRot);

            Projectile p = clone.GetComponent<Projectile>();

            DestroyOnLifeTime q = clone.GetComponent<DestroyOnLifeTime>();

            // Damage Upgrades
            if (bunkerUI.GetComponent<Upgrades>().damageTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == false)
                {
                    p.damage = p.damage * 2f;
                }

                if (bunkerUI.GetComponent<Upgrades>().damageTech3 == true)
                {
                    p.damage = p.damage * 3f;
                }
            }

            // Range Upgrades
            if (bunkerUI.GetComponent<Upgrades>().rangeTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == false)
                {
                    q.lifeTime = q.lifeTime * 1.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().rangeTech3 == true)
                {
                    q.lifeTime = q.lifeTime * 2f;
                }
            }

            // Accuracy Upgrades
            if (bunkerUI.GetComponent<Upgrades>().accuracyTech2 == true)
            {
                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == false)
                {
                    p.speed = p.speed * 2f;
                    q.lifeTime = q.lifeTime * 0.5f;
                }

                if (bunkerUI.GetComponent<Upgrades>().accuracyTech3 == true)
                {
                    p.speed = p.speed * 3f;
                    q.lifeTime = q.lifeTime * 0.35f;
                }
            }

            p.direction = fireDirection;

            return;
        }
        #endregion
    }
    #endregion
}

