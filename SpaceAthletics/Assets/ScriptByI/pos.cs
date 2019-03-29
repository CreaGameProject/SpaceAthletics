using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos : MonoBehaviour {

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Planet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = Player.transform.position;
        this.transform.LookAt((Player.transform.position - Planet.transform.position)*1.5f);
		
	}
}
