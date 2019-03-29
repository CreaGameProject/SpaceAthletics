using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    [SerializeField] int distanceMin;
    [SerializeField] int distanceMax;
    [SerializeField] float distanceAngle;
    [SerializeField] float zoomSpeed;
    [SerializeField] float cameraSpeed;

    //[SerializeField] GameObject Player;
    [SerializeField] GameObject Planet;

    float distance = 5;
    float cameraAngle =0;

    
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

       
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

    void GetBec()
    {
        //keepBec = Player.transform.eulerAngles.y * (Mathf.PI / 180f);
        //Bec = new Vector3(Mathf.Sin(keepBec), 0, Mathf.Cos(keepBec));
        //Debug.Log(Bec.x + " " + Bec.y + " " + Bec.z);
    }

    float GetCita(Vector3 a, Vector3 b)
    {

        //Debug.Log(becInnerProject(a,b));
        //Debug.Log(becAbs(a));
        //Debug.Log(becAbs(b));

        float cita = becInnerProject(a,b)/ becAbs(a)/ becAbs(b)  ;

        cita = Mathf.Floor(cita);

        Debug.Log(cita);
        Debug.Log(Mathf.Acos(1));
        Debug.Log(Mathf.Acos(cita));
    
        return Mathf.Acos(cita)*180/Mathf.PI;
    }

    float becInnerProject(Vector3 a, Vector3 b)
    {
        float innerProject = (a.x * b.x + a.y * b.y + a.z * b.z);

        return innerProject;
    }

    float becAbs(Vector3 vector)
    {
        float abs = (vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z);

        abs = Mathf.Sqrt(abs);

        return abs;
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

        
        transform.localPosition = new Vector3( Mathf.Cos(cameraAngle / 180 * Mathf.PI) * -distance ,
           Mathf.Sin(cameraAngle / 180 * Mathf.PI) * distance , Mathf.Sin(distanceAngle / 180 * Mathf.PI) * distance );

        transform.rotation = Quaternion.LookRotation(transform.parent.position - transform.position, (transform.parent.position - Planet.transform.position) * 10);

        //this.transform.LookAt(transform.parent.position);
        //this.transform.localRotation = Quaternion.LookRotation(transform.parent.position, (Player.transform.position - Planet.transform.position) * 1.5f);
    }
}
