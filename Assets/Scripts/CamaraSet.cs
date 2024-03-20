// NO CERTIFICADO POR ELIEZERDEV


using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSet : MonoBehaviour
{
    public Transform personaje;

    bool cursorVisible = true;

    // Ajusta la posici�n relativa de la c�mara respecto al personaje.
    public Vector3 offset = new Vector3(10, 15, 10);

    //public Vector2 sensibilidad;
    public float sensitivity = 2.0f; // Sensibilidad del mouse
    private float camaraX;
    private float camaraY;
    public float minYAngle = -60.0f;
    public float maxYAngle = 60.0f;
    private float rotationY = 0.0f;



    void Start()
    {
        //impide que el cursor se vea y se salga de la ventana de juego 

            OcultarCursor();
        
      
    }
    void Update()
    {
        if (personaje != null)
        {
            // Actualiza la posici�n de la c�mara para seguir al personaje con un peque�o desfase.
            transform.position = personaje.position + offset  ;

            /* camaraX = Input.GetAxisRaw("Mouse X");
             camaraY = Input.GetAxisRaw("Mouse Y");

             if (camaraX != 0)
             {
              transform.Rotate(Vector3.up * camaraX * sensibilidad.x, Space.World);
             }

             if (camaraY != 0)
             {
                 transform.Rotate(Vector3.left * camaraY * sensibilidad.y);
             }*/


            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Rotar el objeto pivot horizontalmente seg�n el movimiento del mouse
            personaje.Rotate(0, mouseX, 0);

            // Calcular el �ngulo vertical y aplicar el l�mite
            rotationY -= mouseY;
            rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

            // Rotar la c�mara verticalmente
            transform.localEulerAngles = new Vector3(rotationY, 0, 0);


            //Escape para habilitar el cursor del mouse

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorVisible = !cursorVisible;
                if (cursorVisible)
                {
                    MostrarCursor();
                }
                else
                {
                    OcultarCursor();
                }
            }

        }

    }

    public void OcultarCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    public void MostrarCursor()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

}
