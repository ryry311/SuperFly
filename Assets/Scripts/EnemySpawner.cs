using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        //Debug.Log(transform.name);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning()
    {
        CancelInvoke();
    }

    /*void OnTriggerEnter(Collider other)
    {
      Debug.Log(other.gameObject.name);
      //if (other.gameObject.CompareTag ("Shot"))
      //{
        health -= 5;
        Debug.Log("hit");
        if (health <= 0) {
          Destroy(gameObject);
        }
      //}
      //GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
      //transform.rotation) as GameObject;
    }*/
}
