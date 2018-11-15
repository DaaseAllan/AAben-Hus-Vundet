using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandling : MonoBehaviour {

    public GameObject ObstacleGenerator;
    public GameObject PlayerBall;

    public GameObject OpenBallsBtn;
    public GameObject CloseBallsBtn;
    public GameObject ChooseBallsPanel;
    public Text ScoreText;

    public bool gameIsActive = false;
    private bool gameReadyToStart = true;

    public float Score;
    public float gameSpeed = 0.1f;

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
        ScoreText.text = ((int)Score).ToString();
        if(ObstacleGenerator.GetComponent<ObstacleGen>().gameIsActive == true)
        {
            ObstacleGenerator.GetComponent<ObstacleGen>().gameSpeed += Time.deltaTime * 0.1f;

            Score += Time.deltaTime;
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
        OpenBallsBtn.SetActive(true);
        ObstacleGenerator.GetComponent<ObstacleGen>().gameSpeed = 7;
        Score = 0;
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

            PlayerBall.GetComponent<BallHandler>().GetBallBonuses();
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
 