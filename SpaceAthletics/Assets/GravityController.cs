using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    public GameObject player;
    Rigidbody playerRigidbody;
    Rigidbody planetRigidbody;
    public float g;
    Vector3 pos;
    Vector3 basePos;
    
    // Use this for initialization
	void Start ()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        planetRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        GravityManager();
    }

    private void GravityManager()
    {
        pos = player.transform.position;
        basePos = transform.position;

        Vector3 gravityDirection = basePos - pos;
        Vector3 gravityScaler = g * gravityDirection.normalized * (planetRigidbody.mass * playerRigidbody.mass) / (gravityDirection.sqrMagnitude);
        playerRigidbody.AddForce(gravityScaler);
    }
}
