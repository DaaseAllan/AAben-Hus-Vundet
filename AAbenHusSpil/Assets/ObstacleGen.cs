using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour {

    public float gameSpeed;
    public List<GameObject> obstacleMarkers;
    public List<GameObject> ObstaclePrefabs;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
        {
            obstacleMarkers.Add(child.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject Marker in obstacleMarkers)
        {
            Marker.transform.position += Vector3.down * gameSpeed * Time.deltaTime;
            if(Marker.transform.position.y <= -20)
            {
                print("resetter marker");
                ResetObstacleMarker(Marker);
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void ResetObstacleMarker(GameObject Marker)
    {
        //Flytter objektet tilbage til toppen
        Marker.transform.position = new Vector3(0, 20, 0);

        //Sletter det prefab som er på objektet nu
        foreach (Transform child in Marker.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //Tilføjer et nyt prefab fra listen
        print(Random.Range(0, ObstaclePrefabs.Count));
        Instantiate(ObstaclePrefabs[Random.Range(0,ObstaclePrefabs.Count)], Marker.transform);
    }
}
