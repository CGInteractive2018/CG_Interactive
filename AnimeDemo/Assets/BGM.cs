using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;

    void Start()
    {
    }

    private void Update()
    {
        if (ScoreText.alive == false || ScoreText2.alive == false) {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
    }
}