using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private float rotationSpeed = 60f;
    private float movementSpeed = 10f;

    void Update()
    {
      transform.Rotate(Input.GetAxis("Vertical")*rotationSpeed*Time.deltaTime, Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime, Input.GetAxis("Occidental")*rotationSpeed*Time.deltaTime);
      transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
