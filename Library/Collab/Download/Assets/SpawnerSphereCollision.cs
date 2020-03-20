using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSphereCollision : MonoBehaviour
{
  public int health = 30;

    void OnTriggerEnter(Collider other)
    {
      //if (other.gameObject.CompareTag ("Shot"))
      //{
        health -= 5;
        Debug.Log("hit");
        if (health <= 0) {
          Destroy(transform.parent.gameObject);
          Manager.level1Enemies -= 1;
        }
      //}
      //GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
        //transform.rotation) as GameObject;
    }
}
