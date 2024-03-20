using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using Photon;

public class Movimiento : MonoBehaviourPunCallbacks
{
    private float horizontal;
    private float vertical;
   
    public Transform cameraTransform;
    Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   

    void FixedUpdate()
    {

        if (photonView.IsMine)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            var m = (cameraTransform.forward * vertical + cameraTransform.right * horizontal) * Time.deltaTime * 100;
            //rb.velocity = ;
            rb.velocity = new Vector3(m.x, rb.velocity.y, m.z);
        }
       


    }

    
}
