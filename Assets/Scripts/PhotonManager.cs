using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    int SpawnedPlayers = 0;
    List<GameObject> playerObjets = new List<GameObject>();
    public GameObject playerPrefab;

    //acceder a photon
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    //conectado a internet
    public override void OnConnectedToMaster()
    {

        PhotonNetwork.JoinLobby();
        print("contado a internet");
    }

    //se unio a un lobby
    public override void OnJoinedLobby()
    {

        PhotonNetwork.JoinRandomOrCreateRoom();
        print("se conecto a un lobby");
    }

    //se unio a un room del lobby
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnedPlayers++;
            if (PhotonNetwork.IsMasterClient && playerObjets.Count < PhotonNetwork.PlayerList.Length && SpawnedPlayers == PhotonNetwork.PlayerList.Length)
            {
                photonView.RPC(nameof(SpawnPlayer), RpcTarget.AllBuffered);
                print("se conecto a un room");

            }
        }

    }
    [PunRPC]
    public void SpawnPlayer()
    {

       var player= PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        player.name = player.GetComponent<PhotonView>().name;
        playerObjets.Add(player);
        player.GetComponent<PlayerManager>().photonView.RPC(nameof(PlayerManager.apagarComponents),RpcTarget.AllBuffered) ;

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        SpawnedPlayers--;
        foreach (GameObject gameObject in playerObjets) 
        {
            if(gameObject.name == otherPlayer.NickName)
            {
                playerObjets.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
