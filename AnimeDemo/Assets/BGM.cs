using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;
    private bool gameOver = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        //audioSource.Play();
    }

    private void Update()
    {
        if( (ScoreText.alive == false || ScoreText2.alive == false) && (gameOver == false) ){
            //audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.clip = audioClip1;
            audioSource.Play();
            gameOver = true;
        }
    }
}