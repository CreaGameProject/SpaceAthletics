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

    float keepBec;
    float oldBec;

    // Use this for initialization
    void Start()
    {

        keepBec = Player.transform.localEulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {


        //keepBec = Player.transform.localEulerAngles.y;
        //cameraAngle += keepBec - oldBec;
        //oldBec = keepBec;

        //if (Input.GetKeyDown(KeyCode.S))
        //{

        //    Debug.Log(Player.transform.localEulerAngles.y);

        //}



        if (Input.GetKey(KeyCode.RightArrow))
        {
            cameraAngle += cameraSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
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
            cameraAngle = 0;
        }
        else if (cameraAngle < 0)
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

        transform.localPosition = new Vector3(Mathf.Sin(cameraAngle / 180 * Mathf.PI) * distance,
            Mathf.Sin(distanceAngle / 180 * Mathf.PI) * distance, Mathf.Cos(cameraAngle / 180 * Mathf.PI) * -distance);

        this.transform.LookAt(transform.parent);
    }
}

