using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfo : MonoBehaviour
{
    public Shark clientRef;
    private LobbyManager lobbyManager;


    private void Start()
    {
        lobbyManager = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
    }

    public void PopulateSharkInfo()
    {
        lobbyManager.sharkInfo = clientRef;
        lobbyManager.OpenClientInfo();
    }     

}
