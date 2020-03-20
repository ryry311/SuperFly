using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] float visibilityCounter = .5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;

    LineRenderer lr;
    bool canFire;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lr.enabled = false;
        canFire = true;
    }

    /*
    private void Update()
    {

    }
    */  

    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if(Physics.Raycast(transform.position, fwd, out hit))
        {
            return hit.point;
        }
        return transform.position + (transform.forward * maxDistance);
    }

    public void FireWeapon()
    {
        if (canFire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, CastRay());
            lr.enabled = true;
            canFire = false;
            Invoke("TurnOffWeapon", visibilityCounter);
            Invoke("CanFire", fireDelay);

        }
    }

    void TurnOffWeapon()
    {
        lr.enabled = false;
    }

    public float Distance
    {
        get { return maxDistance; }
    }

    void CanFire()
    {
        canFire = true;
    }
}
