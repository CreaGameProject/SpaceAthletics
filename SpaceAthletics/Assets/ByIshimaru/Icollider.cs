using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Icollider : MonoBehaviour {

    //[SerializeField] int planetNum;
    [SerializeField] string planetName;

    selectUI selectUI;

	// Use this for initialization
	void Start () {

        selectUI = GameObject.Find("Canvas").GetComponent<selectUI>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadSceneAsync(planetName + "Scene");
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log(planetName);
        }

        selectUI.planetName = planetName;

    }

    private void OnTriggerExit(Collider other)
    {
        selectUI.planetName = " ";
    }
}
