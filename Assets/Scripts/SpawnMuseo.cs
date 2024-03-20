using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMuseo : MonoBehaviourPunCallbacks
{
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            if (photonView.IsMine && players != null)
            {
                player.transform.position = this.transform.position;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
