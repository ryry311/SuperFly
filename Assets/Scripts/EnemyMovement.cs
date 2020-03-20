using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float movementSpeed = 20f;

    // For pathfinding around objects
    [SerializeField] float detectionDistance = 100f;
    [SerializeField] float rayCastOffset = 2.5f;

    public GameObject explosion;

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
        PathFinding();
        Move();
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 appliedOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.Log("LINE OF SIGHT!");
            }
            appliedOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.Log("LINE OF SIGHT!");
            }
            appliedOffset -= Vector3.right;
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.Log("LINE OF SIGHT!");
            }
            appliedOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                //Debug.Log("LINE OF SIGHT!");
            }
            appliedOffset += Vector3.up;
        }

        if (appliedOffset != Vector3.zero)
        {
            transform.Rotate(appliedOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }

    bool FindTarget()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(target == null)
        {
            return false;
        }
        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("missile hit something");
        if (other.gameObject.CompareTag("Obstacle")) {
            Debug.Log("missile hit obstacle");
            GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
              transform.rotation) as GameObject;
            gameObject.SetActive (false);
        }
        else if (other.gameObject.CompareTag("Player")) {
            Debug.Log("missile hit player");
            GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
              transform.rotation) as GameObject;
            gameObject.SetActive (false);
        }
    }

}
