using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public GameObject menu_opciones;
    public GameObject otro_Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu_opciones.gameObject.activeSelf == true)
            {
                menu_opciones.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            menu_opciones.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

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
        if (otro_Menu.gameObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
            

    }
}
