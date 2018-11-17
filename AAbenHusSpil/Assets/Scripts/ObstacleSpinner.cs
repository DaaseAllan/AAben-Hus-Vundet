using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinner : MonoBehaviour {
    private float rotateSpeed = 50;
    public float speedVariation;
    private float rotation;

    

	// Use this for initialization
	void Start () {
        speedVariation = Random.Range(-speedVariation, speedVariation);

        if(Random.Range(-1,1) > 0)
        {
            rotation = 1;
        }
        else
        {
            rotation = -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * (rotateSpeed + speedVariation) * rotation * Time.deltaTime);
    }


}
