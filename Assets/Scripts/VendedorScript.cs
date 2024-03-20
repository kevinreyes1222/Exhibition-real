using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendedorScript : MonoBehaviour
{
    public AudioClip audioClip; 
    private AudioSource audioSource;
    private bool clipPlayed = false;
   
    private bool animationPlayed = false;
    public Animator animador;
    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
       
        audioSource.clip = audioClip;
    }

 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !clipPlayed)
        {
            // Reproducir el clip de audio
            audioSource.Play();
            clipPlayed = true;
        }

        if (!animationPlayed)
        {
          
            
            animationPlayed = true;
            animador.SetTrigger("talking");
        }
    }
}
