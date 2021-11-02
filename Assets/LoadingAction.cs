using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
            StartCoroutine(GameObject.Find("CheckWave").GetComponent<CheckWave>().WaveStart(4f));

    }

    // Update is called once per frame
    void Update () {
		
	}
}
