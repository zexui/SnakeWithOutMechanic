using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadLaver : MonoBehaviour {

    public GameObject Mad;
    GameObject MadSpawn;

    public Transform Top;
    public Transform Bund;
    public Transform Højre;
    public Transform Venstre;

	// Use this for initialization
	void Start () {

        int x = (int)Random.Range(Venstre.position.x, Højre.position.x);

        int y = (int)Random.Range(Bund.position.y, Top.position.y);

        MadSpawn = Instantiate(Mad, new Vector2(x, y), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(MadSpawn);

        int x = (int)Random.Range(Venstre.position.x, Højre.position.x);

        int y = (int)Random.Range(Bund.position.y, Top.position.y);

        MadSpawn = Instantiate(Mad, new Vector2(x, y), Quaternion.identity);

    }

}
