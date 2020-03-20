using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
	private int timeStep = 0;
    [SerializeField] AudioSource fireSound;


	public GameObject m_shotPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && timeStep <= 0) {
            fireSound.Play();
        	GameObject shot = GameObject.Instantiate(m_shotPrefab, transform.position, 
        		transform.rotation) as GameObject;
        	timeStep = 10;
        }
        timeStep -= 1;

    }
}
