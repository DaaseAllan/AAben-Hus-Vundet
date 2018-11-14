using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour {

    public GameObject gameHandler;
    public GameHandling.BallTypes ballType;


    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(gameHandler.GetComponent<GameHandling>().gameIsActive == true)
        {
            gameHandler.GetComponent<GameHandling>().gameLose();
            rb.velocity = new Vector2(0, 0);
        }
    }

    //Funktioner til at vælge bolden
    public void PickBallType(string chosenBallType)
    {
        switch (chosenBallType)
        {
            case "Normal":
                ballType = GameHandling.BallTypes.Normal;
                break;
            case "Test":
                ballType = GameHandling.BallTypes.Test;
                break;
        }
        GetComponent<BallMovement>().UpdateBall();
    }
}
