using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour {

    public float gameSpeed;
    public List<GameObject> obstacleMarkers;
    public List<GameObject> ObstaclePrefabs;
    public bool gameIsActive = false;


	// Use this for initialization
	void Start () {
        //LAver en liste over alle markers
        foreach (Transform child in transform)
        {
            obstacleMarkers.Add(child.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameIsActive)
        {
            foreach (GameObject Marker in obstacleMarkers)
            {
                //Flytter markersne ned
                Marker.transform.position += Vector3.down * gameSpeed * Time.deltaTime;
                if (Marker.transform.position.y <= -20)
                {
                    //Flytter markersne tilbage til toppen
                    ResetObstacleMarker(Marker);
                }
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
        Instantiate(ObstaclePrefabs[Random.Range(0,ObstaclePrefabs.Count)], Marker.transform);
    }

    public void StartGen()
    {
        //Spawner
        gameIsActive = true;
    }

    public void StopGen()
    {
        gameIsActive = false;
    }

    public void RemoveAllObstacles()
    {
        foreach(GameObject marker in obstacleMarkers)
        {
            foreach(Transform child in marker.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
