using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinner : MonoBehaviour {
    public float rotateSpeed = 50;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }


}
