using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{

    public static bool invertVertical = false;
    public static bool swapMovement = false;

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
    public GameObject explosion;

    // How much boost the player has
    public float boostMax = 100f;
    public float boostLevel = 100f;
    public float regenTime = 0f;


    private bool boosting = false;
    private int deathCounter = -1;

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

        if(swapMovement && invertVertical)
        {
            transform.Rotate(Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime * -1,
          Input.GetAxis("Occidental") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }
        else if (swapMovement)
        {
            transform.Rotate(Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Occidental") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        }
        else if (invertVertical) {
            transform.Rotate(Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime * -1,
          Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Occidental") * rotationSpeed * Time.deltaTime);
        } 
        else
        {
            transform.Rotate(Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime,
          Input.GetAxis("Occidental") * rotationSpeed * Time.deltaTime);
        }
      

      if (powerUp.started || (Input.GetKey("left shift") && powerUp.available)) {
        powerUp.started = true;
        HandlePowerUp();
      }

        // Moves you forward
        transform.position += transform.up * Time.deltaTime * totalSpeed;

      
      textField.text = "POWER UP: " + powerUp.type.ToUpper();

      if (deathCounter != -1) {
        deathCounter -= 1;
        if (deathCounter == 0) {
          //gameObject.SetActive(false);
          SceneManager.LoadScene (sceneName:"GameOver");
          Manager.level1Enemies = 2;
        }
      }
    }

    void HandleBoost() {

      if (boosting) {
        if (boostLevel > 0f) {
          boostLevel -= .2f;
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

        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Spawner")) {
           Debug.Log("Suicide!");
           GameObject sheesh = GameObject.Instantiate(explosion, transform.position,
             transform.rotation) as GameObject;
           deathCounter = 5;
        }
    }
}
