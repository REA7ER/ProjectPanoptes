using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    LifeSource lifeSource;
    bool isLoad = false;

	// Use this for initialization
	void Start () {
        lifeSource = new LifeSource();
        lifeSource.hp = 100f;
        lifeSource.mp = 0f;
        lifeSource.currStatus = 0;

        if (isLoad) {
            // load data from save file
        }

        lifeSource.initated = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
