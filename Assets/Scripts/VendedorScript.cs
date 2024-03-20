using JetBrains.Annotations;
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

    public GameObject canvas;

    public GameObject transportador;
    private void Start()
    {
        //transportador.GetComponent<MeshRenderer>();
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
            animador.SetBool("notTalking", true);
        }

        

       
    }
    public void EncenderUi()
    {
        canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CerrarUi()
    {
        canvas.gameObject.SetActive(false);
        transportador.GetComponent <MeshRenderer>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
