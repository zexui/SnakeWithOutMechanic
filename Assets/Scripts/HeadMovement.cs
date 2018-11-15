using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadMovement : MonoBehaviour {

    Vector2 retning;

    List<GameObject> HaleObject = new List<GameObject>();

    bool Spist = false;
    public GameObject HalePrefab;

    public int MaxLaengde;

    public GameObject Snake;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Movement", 0.25f, 0.25f);
        InvokeRepeating("Grow", 3f, 3f);
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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            retning = Vector2.right;
        }
    }

    void Movement()
    {
        Vector2 CurrentPos = transform.position;

        transform.Translate(retning);

        if (Spist == true && HaleObject.Count > 0)
        {

            Destroy(HaleObject.Last());
            HaleObject.Remove(HaleObject.Last());
            

            Spist = false;
        }

        if (HaleObject.Count > 0)
        {
            HaleObject.Last().transform.position = CurrentPos;

            HaleObject.Insert(0, HaleObject.Last());
            HaleObject.RemoveAt(HaleObject.Count - 1);

        }

        if (HaleObject.Count > MaxLaengde)
        {
            SceneManager.LoadScene("Death");
        }

    }
        
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

    void Grow ()
    {
        Vector2 CurrentPos = transform.position;

        GameObject HalePre = (GameObject)Instantiate(HalePrefab, CurrentPos, Quaternion.identity);

        HaleObject.Insert(0, HalePre);
    }

}

