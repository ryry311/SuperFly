using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BoostBar : MonoBehaviour
{

	public float currentBoost { get; set; }
    public float maxBoost { get; set; }

	//public BoostBar boostBar;
    // Start is called before the first frame update

    public Slider boostBar;


    void Start()
    {

    	maxBoost = 20f;
        currentBoost = maxBoost;
        //boostBar.value = CalculateBoost();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");

        ArrowController ship = player.GetComponent<ArrowController>();

        //Debug.Log(ship.boostLevel);

        boostBar.value = ship.boostLevel;

    }
}
