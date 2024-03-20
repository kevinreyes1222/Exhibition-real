using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_pausa : MonoBehaviour
{
    public GameObject menupausa;
    public GameObject otro_Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menupausa.gameObject.activeSelf == true)
            {
                menupausa.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            menupausa.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Cerrar()
    {
        menupausa.gameObject.SetActive(false);
        if (otro_Menu.gameObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }
}
