using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour {

    public GameObject gameHandler;
    public GameHandling.BallTypes ballType;
    public int bonusLives;

    //RImelig hurtig løsning
    public Material normalMat;
    public Material testMat;


    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        print(bonusLives);
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(gameHandler.GetComponent<GameHandling>().gameIsActive == true)
        {
            if(bonusLives <= 0)
            {
                //Du dør
                gameHandler.GetComponent<GameHandling>().gameLose();
                rb.velocity = new Vector2(0, 0);

            }
            else
            {
                //Du overlever
                GameObject.Destroy(collision.gameObject);
                bonusLives -= 1;
            }

        }
    }

    //Funktioner til at vælge bolden
    public void PickBallType(string chosenBallType)
    {
        switch (chosenBallType)
        {
            case "Normal":
                ballType = GameHandling.BallTypes.Normal;
                GetComponent<MeshRenderer>().material = normalMat;
                break;
            case "Test":
                ballType = GameHandling.BallTypes.Test;
                GetComponent<MeshRenderer>().material = testMat;
                break;
        }
        GetComponent<BallMovement>().UpdateBall();
    }


    //Bliver kaldt af gamehandler
    public void GetBallBonuses()
    {
        switch (ballType)
        {
            case GameHandling.BallTypes.Normal:
                bonusLives = 0;
                break;
            case GameHandling.BallTypes.Test:
                bonusLives = 1;
                break;
        }
    }
}
