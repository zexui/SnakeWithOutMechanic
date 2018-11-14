using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

    Vector2 retning;

    List<Transform> Hale = new List<Transform>();
    List<GameObject> HaleObject = new List<GameObject>();

    bool Spist = false;
    public GameObject HalePrefab;

    public GameObject Snake;
    Vector2 Startpos = new Vector2(0.0f, 0.0f); 

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

        if (Spist == true && Hale.Count > 0)
        {
            Destroy(HaleObject.Last());
            HaleObject.Remove(HaleObject.Last());
            Hale.Remove(Hale.Last());

            Spist = false;
        }

    }

    void Movement()
    {
        Vector2 CurrentPos = transform.position;

        transform.Translate(retning);

        if (Hale.Count > 0)
        {
            Hale.Last().position = CurrentPos;

            Hale.Insert(0, Hale.Last());
            Hale.RemoveAt(Hale.Count - 1);
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
            transform.position = Startpos;
        }

    }

    void Grow ()
    {
        Vector2 CurrentPos = transform.position;

        GameObject HalePre = (GameObject)Instantiate(HalePrefab, CurrentPos, Quaternion.identity);

        Hale.Insert(0, HalePre.transform);
        HaleObject.Insert(0, HalePre);
    }

}

