using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectUI : MonoBehaviour {

    [SerializeField] Text planetN;
    [SerializeField] Text eegiru;

    public int eegiruCount =0;
    public string planetName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        eegiru.text = "所持エーギル数　" + eegiruCount;
        planetN.text = planetName;

	}
}
