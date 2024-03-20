using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class Movimiento : MonoBehaviourPunCallbacks
{
    
    public float velocidad = 100f;
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movimiento = new Vector3(horizontal, 0, vertical) * Time.deltaTime * velocidad;
            body.velocity = movimiento;
        }
       
    }
}
