using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPro : MonoBehaviour {

    [SerializeField] int distanceMin;
    [SerializeField] int distanceMax;
    [SerializeField] float distanceAngle;
    [SerializeField] float zoomSpeed;
    [SerializeField] float cameraSpeed;

    [SerializeField] GameObject Player;

    float distance = 5;
    float cameraAngle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(Player.transform);

	}

    void KeepPosition()
    {

    }
}
