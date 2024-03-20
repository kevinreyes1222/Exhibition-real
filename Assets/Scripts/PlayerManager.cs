using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Unity.VisualScripting;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject camarita;
    Transform player; 
     void Start()
    {
        player = camarita.transform.parent;
        photonView.RPC(nameof(apagarComponents), RpcTarget.AllBuffered); 
    }

    [PunRPC]
    public void apagarComponents()
    {
        if (!photonView.IsMine)
        {
            camarita.SetActive(false);

        }
        DontDestroyOnLoad(camarita.transform.parent);

    }
}
