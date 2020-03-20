using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float accelSpeed = 10f;
    public float movementSpeed = 10f;

    void Update()
    {
      transform.Rotate(Input.GetAxis("Vertical")*rotationSpeed*Time.deltaTime, Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime, Input.GetAxis("Occidental")*rotationSpeed*Time.deltaTime);
      movementSpeed = movementSpeed + Input.GetAxis("Radical") * Time.deltaTime * accelSpeed;
      transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
