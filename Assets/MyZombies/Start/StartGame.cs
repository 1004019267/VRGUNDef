using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (50>=transform.localEulerAngles.z && transform.localEulerAngles.z>=5)
        {
            Application.LoadLevel(1);
        }
	}
}
