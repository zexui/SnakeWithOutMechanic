using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{

    public AudioClip Musik;
    public AudioClip Eat;
    public AudioClip Death;

    public AudioSource LydSourceMusik;
    public AudioSource LydSourceEat;
    public AudioSource LydSourceDeath;


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            LydSourceMusik.clip = Musik;
            LydSourceEat.clip = Eat;
            BackgroundMusic();

        }
        else if (SceneManager.GetActiveScene().name == "Death") 
        {
            LydSourceDeath.clip = Death;
            DeathSound();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("HvidCirkel"))
        {
            LydSourceEat.Play();
        }
    }

    void BackgroundMusic ()
    {
        LydSourceMusik.Play();
    }
    
    void DeathSound ()
    {
        LydSourceDeath.Play();
    }

}
