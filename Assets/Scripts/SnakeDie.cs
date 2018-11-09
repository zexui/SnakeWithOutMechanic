using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDie : MonoBehaviour {

    public GameObject Snake;
    Vector2 Startpos = new Vector2(0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            transform.position = Startpos;
        }

    }


}
