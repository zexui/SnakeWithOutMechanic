using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float TidTilbage;

    Text Tid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        TidTilbage -= Time.deltaTime;

        Tid = GetComponent<Text>();
        Tid.text = "Time: " + TidTilbage.ToString();

        if(TidTilbage < 0)
        {
            SceneManager.LoadScene("Win");
        }
	}
}
