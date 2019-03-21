using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour {

    GameObject player;
    Vector3 playerPos;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Main Camera").GetComponent<CameraMove>().player;
        playerPos = player.transform.position;
        transform.position = playerPos;
    }

    // Update is called once per frame
    void Update () {
        playerPos = player.transform.position;
        transform.position = playerPos;
    }
}
