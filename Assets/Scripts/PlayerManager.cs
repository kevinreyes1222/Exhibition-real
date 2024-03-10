using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject camarita;
     void Start()
    {
        photonView.RPC(nameof(apagarComponents), RpcTarget.AllBuffered); 
    }

    [PunRPC]
    public void apagarComponents()
    {
        if (!photonView.IsMine)
        {
            camarita.SetActive(false);

        }
    }
}
