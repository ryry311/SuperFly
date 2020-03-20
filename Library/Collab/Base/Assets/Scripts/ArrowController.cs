using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private class PowerUp {
        public bool available;
        public string type;
        public int counter;
        public bool started;
        public PowerUp() {
          this.available = false;
          this.type = "none";
          this.counter = 0;
          this.started = false;
        }
        public void clear()
        {
          this.available = false;
          this.type = "none";
          this.counter = 0;
          this.started = false;
        }
    }

    public PlayerHealth playerHealth;
    public Text textField;
    public float rotationSpeed;
    public float movementSpeed;
    public float boostSpeed;
    public int powerUpLen;

    // How much boost the player has
    public float boostMax = 100f;
    public float boostLevel = 100f;
    public float regenTime = 0f;


    private bool boosting = false;

    private float totalSpeed;

    private PowerUp powerUp = new PowerUp();
    private void Awake ()
    {
      playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
      if (Input.GetKeyDown("left shift")) {
        boosting = true;
      }
      if (Input.GetKeyUp("left shift")) {
        regenTime = 40f;
        boosting = false;
      }
      HandleBoost();

      transform.Rotate(Input.GetAxis("Vertical")*rotationSpeed*Time.deltaTime, Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime, Input.GetAxis("Occidental")*rotationSpeed*Time.deltaTime);
      if (powerUp.started || (Input.GetKey("left shift") && powerUp.available)) {
        powerUp.started = true;
        HandlePowerUp();
      }
      transform.position += transform.up * Time.deltaTime * totalSpeed;
      textField.text = "POWER UP: " + powerUp.type.ToUpper();
    }

    void HandleBoost() {

      if (boosting) {
        if (boostLevel > 0f) {
          boostLevel -= .5f;
          totalSpeed = movementSpeed + boostSpeed;
        }

        if (boostLevel <= 0) {
          totalSpeed = movementSpeed;
          if (regenTime <= 0) {
            regenTime = 45f;
          }
        }

      }
      else {
        totalSpeed = movementSpeed;
        if (boostLevel < boostMax && regenTime <= 0f) {
          boostLevel += 1f;
        }
        if (regenTime > 0) {
          regenTime -= 1f;
        }
      }
    }

    void HandlePowerUp()
    {
      if (powerUp.type == "boost") {
          transform.position += transform.up * Time.deltaTime * movementSpeed * 20;
      }
      else if (powerUp.type == "health") {
          playerHealth.currentHealth = System.Math.Min(playerHealth.maxHealth, playerHealth.currentHealth + 5);
          playerHealth.takeDamage(0);
          powerUp.clear();
      }

      if (powerUp.counter <= 0) {
          powerUp.clear();
      }
      else {
          powerUp.counter -= 1;
      }
    }

    void UpdatePowerUp(Collider other)
    {
        if (powerUp.started) {
            powerUp.clear();
        }
        powerUp.available = true;
        powerUp.type = other.gameObject.GetComponent<PowerUpController>().type;
        if (powerUp.type == "boost") {
            powerUp.counter = powerUpLen;
        }
        else if (powerUp.type == "health") {
            powerUp.started = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("PowerUp"))
        {
            UpdatePowerUp(other);
            other.gameObject.SetActive (false);
        }

        if (other.gameObject.CompareTag("Obstacle")) {
           //Debug.Log("Hit!");
        }
    }
}
