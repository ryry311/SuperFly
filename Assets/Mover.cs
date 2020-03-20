using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

	private bool open = false;
	private int openLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//&& Manager.level1Enemies <= -9
    	if (open == false  && openLevel < 2000) {
        	transform.position -= transform.forward * Time.deltaTime;
            openLevel++;
        }
        
    }
}
