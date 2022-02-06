using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject myLaser;
    public GameObject bulletSpawn;
    public float attackTimerValue;
    private float attackTimerMax;
    private bool canAttack;
    public bool autoShoot;
    // Start is called before the first frame update
    void Start()
    {
        attackTimerMax = attackTimerValue;
    }

    // Update is called once per frame
    void Update()
    {
        FireLaser();
    }

    void FireLaser()
    {
        attackTimerValue += Time.deltaTime;
        if (attackTimerValue >= attackTimerMax)
        {
            canAttack = true;
        }

        if (Input.GetButton("Fire1") || autoShoot)
        {
            if (canAttack)
            {
                canAttack = false;
                attackTimerValue = 0f;

                Instantiate(myLaser, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            }

        }
    }
}
