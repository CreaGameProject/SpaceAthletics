using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstageSelect : MonoBehaviour {

    [SerializeField] float markerSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, markerSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, -markerSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(markerSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-markerSpeed, 0, 0);
        }

    }

    void planetJump()
    {

    }
}
