using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{

    public List<Sprite> Backgrounds = new List<Sprite>();
    public List<Image> LobbyObjects = new List<Image>();


    public Image LobbyBG;

    public Text LobbyText;
    public Text MoneyText;

    private void Awake()
    {
        //Does what it says it does (hopefully)
        SetupLobby();
    }


    private void SetupLobby()
    {
        SetLobbyText();
        SetLobbyBG();
    }



    //Sets Lobby Text based on values in GameManager
    private void SetLobbyText()
    {
        LobbyText.text = "Lobby Level: " + GameManager.main.lobbyLevel.ToString();
        MoneyText.text = "Money: " + GameManager.main.money.ToString();
    }

    //Sets LobbyBG and based on Lobby Upgrade Level
    private void SetLobbyBG()
    {
        switch (GameManager.main.lobbyLevel) 
        {
            case 1:
                LobbyBG.sprite = Backgrounds[0];
                break;
            case 2:
                LobbyBG.sprite = Backgrounds[1];
                break;
            case 3:
                LobbyBG.sprite = Backgrounds[2];
                break;
            case 4:
                LobbyBG.sprite = Backgrounds[2];
                break;
            case 5:
                LobbyBG.sprite = Backgrounds[3];
                break;
            case 6:
                break;
        
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
