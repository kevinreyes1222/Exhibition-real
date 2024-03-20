using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public GameObject menu_opciones;
    public GameObject Menu_tiquet;
    public GameObject menu_pausa;

    

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }   

    public void cambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void Cerrar()
    {
        menu_opciones.gameObject.SetActive(false);
        if (menu_pausa.gameObject.activeSelf == false && Menu_tiquet.gameObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
            

    }
}
