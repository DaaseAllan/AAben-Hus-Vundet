using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandling : MonoBehaviour {

    public GameObject ObstacleGenerator;
    public GameObject PlayerBall;

    public GameObject OpenBallsBtn;
    public GameObject CloseBallsBtn;
    public GameObject ChooseBallsPanel;

    public bool gameIsActive = false;
    private bool gameReadyToStart = true;

    public enum BallTypes
    {
        Normal,
        Test
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
        OpenBallsBtn.SetActive(true);
    }

    public void GameStart()
    {
        if (ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive == false && gameReadyToStart)
        {
            print("Spil startet");
            //Spillet skal startes
            ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive = true;
            gameIsActive = true;
            gameReadyToStart = false;
            OpenBallsBtn.SetActive(false);
        }
    }

    public void OpenChooseBall()
    {
        gameReadyToStart = false;
        OpenBallsBtn.SetActive(false);
        ChooseBallsPanel.SetActive(true);
        CloseBallsBtn.SetActive(true);
    }

    public void CloseChooseBall()
    {
        gameReadyToStart = true;
        OpenBallsBtn.SetActive(true);
        ChooseBallsPanel.SetActive(false);
        CloseBallsBtn.SetActive(false);
    }
}
 