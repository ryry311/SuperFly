using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] EnemyWeapon laser;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!FindTarget())
        {
            return;
        }

        if (InFront() && HaveLineOfSight())
         {
             Debug.Log("FIRE!!");
             FireLaser();
         }

    }

    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, target.position, Color.red);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
        //Debug.DrawRay(laser.transform.position, direction, Color.red);

        if(Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            Debug.DrawRay(laser.transform.position, direction, Color.red);
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireWeapon();
    }

    bool FindTarget()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (target == null)
        {
            return false;
        }
        return true;
    }
}
