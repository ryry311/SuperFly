using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        //explosion = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("missile hit something");
        if (other.gameObject.CompareTag("Obstacle")) {
            Debug.Log("missile hit obstacle");
        }
        else if (other.gameObject.CompareTag("Player")) {
            Debug.Log("missile hit player");
            other.gameObject.GetComponent<PlayerHealth>().takeDamage(2.0f);
        }
        GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
          transform.rotation) as GameObject;
        transform.parent.gameObject.SetActive (false);
    }
}
