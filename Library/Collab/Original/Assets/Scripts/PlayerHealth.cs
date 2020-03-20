using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }

    public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20f;
        currentHealth = maxHealth - 5;
        healthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            takeDamage(5);
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        healthbar.value = CalculateHealth();

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
