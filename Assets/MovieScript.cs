using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovieScript : MonoBehaviour {

    float MovieTime = 0;

    // Use this for initialization
    void Start () {



    }


    // Update is called once per frame
    void Update () {
        
        MovieTime += Time.deltaTime;

        if (MovieTime >= 8)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
