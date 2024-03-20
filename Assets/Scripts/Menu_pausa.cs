using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu_pausa : MonoBehaviourPun
{
    public GameObject menupausa;
    public GameObject otro_Menu;
    private GameObject[] players;
    public bool pausa = false;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (photonView.IsMine && players != null)
            {
                if (pausa == true)
                {
                    print(player);
                    player.gameObject.GetComponent<Movimiento>().enabled = false;
                    player.gameObject.GetComponentInChildren<CamaraSet>().enabled = false;
                }
                else
                {
                    player.gameObject.GetComponent<Movimiento>().enabled = false;
                    player.gameObject.GetComponentInChildren<CamaraSet>().enabled = false;
                }
            }
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = true;
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
            pausa = false;
        }


    }
}
