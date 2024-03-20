// NO CERTIFICADO POR ELIEZERDEV


using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSet : MonoBehaviour
{
    public Transform personaje;

    bool cursorVisible = true;

    // Ajusta la posición relativa de la cámara respecto al personaje.
    public Vector3 offset = new Vector3(10, 15, 10);

    //public Vector2 sensibilidad;
    public float sensitivity = 2.0f; // Sensibilidad del mouse
    
    public float minYAngle = -60.0f;
    public float maxYAngle = 60.0f;
    private float rotationY = 0.0f;

    private void Awake()
    {
        //impide que el cursor se vea y se salga de la ventana de juego 

        OcultarCursor();
    }

    void Start()
    {
        
        
      
    }
    void Update()
    {
        if (personaje != null)
        {
            // Actualiza la posición de la cámara para seguir al personaje con un pequeño desfase.
            transform.position = personaje.position + offset  ;


            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Rotar el objeto pivot horizontalmente según el movimiento del mouse
            personaje.Rotate(0, mouseX, 0);

            // Calcular el ángulo vertical y aplicar el límite
            rotationY -= mouseY;
            rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

            // Rotar la cámara verticalmente
            transform.localEulerAngles = new Vector3(rotationY, 0, 0);


            //Escape para habilitar el cursor del mouse

            /*if (Input.GetKeyDown(KeyCode.Escape))
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
            }*/

        }

    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            OcultarCursor();
        }
        else
        {
            MostrarCursor();
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
