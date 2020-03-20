using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] Text textField;
    [SerializeField] int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Spawner").Length;
        if (enemyCount == 0) {
          SceneManager.LoadScene (sceneName:"GameWon");
        }
        textField.text = "ENEMIES REMAINING: " + enemyCount;
    }
}
