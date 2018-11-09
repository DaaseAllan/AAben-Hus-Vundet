using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandling : MonoBehaviour {
    public GameObject ObstacleGenerator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive == false && Input.GetMouseButtonDown(0))
        {
            //Spillet skal startes
            ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive = true;
            print("her");
        }
	}
}
