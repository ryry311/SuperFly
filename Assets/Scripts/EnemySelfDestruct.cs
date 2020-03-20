using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelfDestruct : MonoBehaviour
{
    private float livingTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", livingTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelfDestruct()
    {
        Debug.Log("Destroying myself...");
        if (transform.parent.gameObject != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
