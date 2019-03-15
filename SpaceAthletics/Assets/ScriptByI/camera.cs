using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    [SerializeField] int distanceMin;
    [SerializeField] int distanceMax;
    [SerializeField] float distanceAngle;
    [SerializeField] float zoomSpeed;
    [SerializeField] float cameraSpeed;

    float distance =5;
    float cameraAngle;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetKey(KeyCode.D))
        {
            transform.parent.Translate(0.1f,0,0); 
        }*/

        if (Input.GetKey(KeyCode.RightArrow))
        {
            cameraAngle += cameraSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            cameraAngle -= cameraSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            cameraAngle = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            distance -= zoomSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            distance += zoomSpeed;
        }

        cameraTrans();

	}

    void cameraTrans()
    {
        if (cameraAngle >= 360)
        {
            cameraAngle -= 360;
        }
        else if (cameraAngle <0)
        {
            cameraAngle += 360;
        }

        if (distance > distanceMax)
        {
            distance = distanceMax;
        }
        else if (distance < distanceMin)
        {
            distance = distanceMin;
        }

        transform.localPosition = new Vector3(Mathf.Sin(cameraAngle)*distance, Mathf.Sin(distanceAngle/180*Mathf.PI)*distance, Mathf.Cos(cameraAngle)*-distance);

        this.transform.LookAt(transform.parent);
    }
}
