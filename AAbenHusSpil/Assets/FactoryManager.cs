using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {

    public List<BallFactory> ballFactories = new List<BallFactory>(new BallFactory[] {
        new BallFactory(GameHandling.BallTypes.Normal, 3, true, false)
});



    public class BallFactory
    {
        public GameHandling.BallTypes ballType;
        public float createTime;
        public bool isUnlocked;
        public bool isBoosted;

        public BallFactory(GameHandling.BallTypes BallType, float CreateTimer, bool IsUnlocked, bool IsBoosted)
        {
            ballType = BallType;
            createTime = CreateTimer;
            isUnlocked = IsUnlocked;
            isBoosted = IsBoosted;
        }
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
