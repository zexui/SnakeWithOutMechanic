using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

    Vector2 retning;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Movement", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            retning =  Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            retning = -Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            retning = -Vector2.right;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            retning = Vector2.right;
        }
    }

    void Movement ()
    {
        transform.Translate(retning);
    }
}
