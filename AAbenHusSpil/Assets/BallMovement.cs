using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float hSpeed;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Wall check
        if(transform.position.x >= 5.1)
        {
            //Skifter retning til venstre
            rb.velocity = new Vector2(-hSpeed, 0);
        }
        else if(transform.position.x <= -5.1)
        {
            //Skifter retning til højre
            rb.velocity = new Vector2(hSpeed, 0);
        }

        //klik med finger
        if (Input.GetMouseButtonDown(0))
        {
            //Tjekker hvilken retning der køres lige nu, og skifter retning
            if(Mathf.Sign(rb.velocity.x) == 1)
            {
                rb.velocity = new Vector3(-hSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(hSpeed, 0);
            }
        }
	}
}
