using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfo : MonoBehaviour
{
    public Shark clientRef;
    public LobbyManager lobbyManager;
    
    public void PopulateSharkInfo()
    {
        lobbyManager.sharkInfo = clientRef;
    }

    public void PlayClient()
    {

    }

    public void Back()
    {

    }


}
