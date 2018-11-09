using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandling : MonoBehaviour {

    public GameObject ObstacleGenerator;
    public GameObject PlayerBall;

    public bool gameIsActive = false;
    private bool gameReadyToStart = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive == false && Input.GetMouseButtonDown(0) && gameReadyToStart)
        {
            //Spillet skal startes
            ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive = true;
            gameIsActive = true;
            gameReadyToStart = false;
        }
	}

    //Is this?
    public void gameLose()
    {
        StartCoroutine(ResetGame());
    }

    //En IEnumerator er en form fpor funktion, hvor at vi kan time ting med WaitForSeconds
    private IEnumerator ResetGame()
    {
        gameIsActive = false;
        ObstacleGenerator.GetComponent<ObstacleGen>().StopGen();
        yield return new WaitForSeconds(3);
        ObstacleGenerator.GetComponent<ObstacleGen>().RemoveAllObstacles();
        gameReadyToStart = true;
        PlayerBall.transform.position = new Vector2(0f, -5.5f);
    }
}
