using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour {

    public GameObject gameHandler;
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
}
