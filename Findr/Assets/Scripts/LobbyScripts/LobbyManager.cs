using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{

    public List<Sprite> Backgrounds = new List<Sprite>();
    public List<GameObject> LobbyObjects = new List<GameObject>();

    public Sprite fixedStool;
    public GameObject SignInBtn;
    public Sprite clientClipboard;

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
        FurnishLobby();
    }



    //Sets Lobby Text based on values in GameManager
    private void SetLobbyText()
    {
        LobbyText.text = "Lobby Level: " + GameManager.main.lobbyLevel.ToString();
        MoneyText.text = "Money: " + GameManager.main.money.ToString();
    }

    //Sets LobbyBG and based on Lobby Upgrade Level
    private void FurnishLobby()
    {
        switch (GameManager.main.lobbyLevel) 
        {
            case 1:
                //Bad BG Pipe + Holes
                LobbyBG.sprite = Backgrounds[0];
                break;

            case 2:
                //Bad BG Holes
                LobbyBG.sprite = Backgrounds[1];
                break;

            case 3:
                //Bad BG
                LobbyBG.sprite = Backgrounds[2];
                break;

            case 4:                
                LobbyBG.sprite = Backgrounds[2];

                //Broken Stool
                LobbyObjects[6].SetActive(true);                
                break;

            case 5:
                //Remove SignInHere WallText
                LobbyObjects[7].SetActive(false);

                //Put up SignIn Clipboard
                LobbyObjects[3].SetActive(true);
                SignInBtn.GetComponent<Image>().sprite = clientClipboard;

                LobbyObjects[6].SetActive(true);

                //Normal BG
                LobbyBG.sprite = Backgrounds[3];
                break;

            case 6:                
                LobbyObjects[7].SetActive(false);                
                LobbyObjects[3].SetActive(true);                
                LobbyBG.sprite = Backgrounds[3];

                //FixUp Stool                
                LobbyObjects[6].SetActive(true);
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;

                break;

            case 7:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(true);
                LobbyBG.sprite = Backgrounds[3];                
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(true);

                //Add Desk
                LobbyObjects[2].SetActive(true);

                break;
            case 8:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(true);
                LobbyBG.sprite = Backgrounds[3];
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(true);                
                LobbyObjects[2].SetActive(true);

                //Add Athena + Nametag
                LobbyObjects[1].SetActive(true);
                LobbyObjects[4].SetActive(true);

                break;
            case 9:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(true);
                LobbyBG.sprite = Backgrounds[3];
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(true);
                LobbyObjects[2].SetActive(true);                
                LobbyObjects[1].SetActive(true);
                LobbyObjects[4].SetActive(true);

                //Add Penholder
                LobbyObjects[5].SetActive(true);

                break;

            case 10:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(true);
                LobbyBG.sprite = Backgrounds[3];
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(true);
                LobbyObjects[2].SetActive(true);
                LobbyObjects[1].SetActive(true);
                LobbyObjects[4].SetActive(true);
                LobbyObjects[5].SetActive(true);

                //Add Window
                LobbyObjects[0].SetActive(true);

                break;

            default:
                //Bad BG Pipe + Holes
                LobbyBG.sprite = Backgrounds[0];
                break;

        
        }
    }
     

    public void UpgradeLobby()
    {
       
        int currentLevel = GameManager.main.lobbyLevel;
        int currentMoney = GameManager.main.money;
        int requiredMoney;

        //Sets requiredMoney based on Lobby level
        switch (currentLevel)
        {
            case 1:
                requiredMoney = 0;
                break;

            case 2:
                requiredMoney = 0;
                break;

            case 3:
                requiredMoney = 0;
                break;

            case 4:
                requiredMoney = 0;
                break;

            case 5:
                requiredMoney = 0;
                break;

            case 6:
                requiredMoney = 0;                
                break;

            case 7:
                requiredMoney = 0;
                break;

            case 8:
                requiredMoney = 0;
                break;

            case 9:
                requiredMoney = 0;
                break;

            case 10:
                requiredMoney = 0;
                break;

            default:
                requiredMoney = 1;
                break;

        }

        //Money check
        if(currentMoney >= requiredMoney)
        {
            GameManager.main.money -= requiredMoney;
            //If Lobby Level is less than 10 add 1 to the lobby level and then set up the lobby with the new furniture.
            if(currentLevel < 10)
            {
                GameManager.main.lobbyLevel += 1;
                SetupLobby();
            }
            else
            {
                //If Lobby Level is 10 or higher print this.
                Debug.Log("You are max level");
            }
        }
    }

    public void OpenClientSelection()
    {

    }

}
