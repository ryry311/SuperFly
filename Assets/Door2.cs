using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
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

    	if (open == false && Manager.level1Enemies <= -9 && openLevel < 2000) {
        	transform.position += transform.right * Time.deltaTime * 10;
            openLevel++;
        }
        
    }
}
