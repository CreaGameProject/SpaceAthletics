using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour {

    [SerializeField] Transform VV;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(VV,new Vector3(0f,100f,0f));

	}
}
