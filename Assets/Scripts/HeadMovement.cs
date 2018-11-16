using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadMovement : MonoBehaviour {

    Vector2 retning;

    List<GameObject> HaleObject = new List<GameObject>();

    bool Spist = false;
    public GameObject HalePrefab;

    public int MaxLaengde;
    public GameObject MaxLaengdeText;

    public GameObject Snake;

    // Use this for initialization
    void Start () {
        //kører tingene inden for de intervaller som er sat
        InvokeRepeating("Movement", 0.25f, 0.25f);
        InvokeRepeating("Grow", 3f, 3f);

        //viser max længde du må være inden du taber
        MaxLaengdeText.GetComponent<Text>().text = "Max Længde: " + MaxLaengde.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        //Bevægelse af slangen
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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            retning = Vector2.right;
        }
    }

    //bevægelse af slangen
    void Movement()
    {
        Vector2 CurrentPos = transform.position;

        transform.Translate(retning);

        //Gør slangen mindre når den spiser
        if (Spist == true && HaleObject.Count > 0)
        {

            Destroy(HaleObject.Last());
            HaleObject.Remove(HaleObject.Last());
            

            Spist = false;
        }
        //sætter sidste hale object til den nuværende position
        if (HaleObject.Count > 0)
        {
            HaleObject.Last().transform.position = CurrentPos;

            HaleObject.Insert(0, HaleObject.Last());
            HaleObject.RemoveAt(HaleObject.Count - 1);

        }

        //dræber dig hvis du er over max længden
        if (HaleObject.Count > MaxLaengde)
        {
            
            SceneManager.LoadScene("Death");
        }

    }
        //tjeker om du rammer en frugt eller om du rammer en væg/dig selv
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("HvidCirkel"))
        {
            Spist = true;
        }
        else
        {
            SceneManager.LoadScene("Death");
        }

    }

    //gør slangen større over tid
    void Grow ()
    {
        Vector2 CurrentPos = transform.position;

        GameObject HalePre = (GameObject)Instantiate(HalePrefab, CurrentPos, Quaternion.identity);

        HaleObject.Insert(0, HalePre);
    }

}


//https://noobtuts.com/unity/2d-snake-game brugt til at få slangen til at gro og fixe nogle problemer med bevægelsen


