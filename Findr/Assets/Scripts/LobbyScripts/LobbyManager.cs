﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    
    public List<Sprite> Backgrounds = new List<Sprite>();
    public List<GameObject> LobbyObjects = new List<GameObject>();

    public Sprite fixedStool;
    public Sprite luxuryAthena;
    public Sprite luxuryDesk;
    public GameObject SignInBtn;
    public Sprite clientClipboard;

    public Image LobbyBG;

    public Text LobbyText;
    public Text MoneyText;
    public GameObject clientSelectionPanel;
    public GameObject upgradeBtn;

    public Shark sharkInfo;
    public GameObject infoPanel;
    public Image infoImage;
    public Text infoName;
    public Text infoBio;
    public GameObject infoTraitPanel;
    public GameObject traitImage;

    
    

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

            case 11:
                LobbyObjects[7].SetActive(false);

                //Remove Clipboard SignIn
                LobbyObjects[3].SetActive(false);

                //Add Lux Lobby BG
                LobbyBG.sprite = Backgrounds[4];

                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(false);

                LobbyObjects[2].SetActive(true);
                LobbyObjects[1].SetActive(true);
                LobbyObjects[4].SetActive(true);
                LobbyObjects[5].SetActive(true);                
                LobbyObjects[0].SetActive(true);
                break;

            case 12:
                LobbyObjects[7].SetActive(false);                
                LobbyObjects[3].SetActive(false);                
                LobbyBG.sprite = Backgrounds[4];
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(false);

                LobbyObjects[2].SetActive(true);

                //Replace Regular Athena with Luxury Athena.
                LobbyObjects[1].GetComponent<Image>().sprite = luxuryAthena;
                LobbyObjects[1].SetActive(true);

                LobbyObjects[4].SetActive(true);
                LobbyObjects[5].SetActive(true);
                LobbyObjects[0].SetActive(true);
                break;

            case 13:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(false);
                LobbyBG.sprite = Backgrounds[4];
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(false);
                LobbyObjects[2].SetActive(true);                
                LobbyObjects[1].GetComponent<Image>().sprite = luxuryAthena;
                LobbyObjects[1].SetActive(true);                
                LobbyObjects[4].SetActive(true);
                LobbyObjects[5].SetActive(true);
                LobbyObjects[0].SetActive(true);

                //Add Luxury Rug
                LobbyObjects[10].SetActive(true);
                break;

            case 14:
                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(false);
                LobbyBG.sprite = Backgrounds[4];
                
                
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(false);
                
                LobbyObjects[11].SetActive(true);

                //Replace Desk with Luxury Desk
                LobbyObjects[2].GetComponent<Image>().sprite = luxuryDesk;
                LobbyObjects[2].SetActive(true);

                LobbyObjects[1].GetComponent<Image>().sprite = luxuryAthena;
                LobbyObjects[1].SetActive(true);

                //Remove penholder and Nametag
                LobbyObjects[4].SetActive(false);
                LobbyObjects[5].SetActive(false);

                LobbyObjects[10].SetActive(true);

                //Remove window
                LobbyObjects[0].SetActive(false);

                //Add Luxury Window
                LobbyObjects[8].SetActive(true);                
                
                break;

            case 15:

                LobbyObjects[7].SetActive(false);
                LobbyObjects[3].SetActive(false);
                LobbyBG.sprite = Backgrounds[4];

                //Remove stool
                LobbyObjects[6].GetComponent<Image>().sprite = fixedStool;
                LobbyObjects[6].SetActive(false);

                LobbyObjects[11].SetActive(true);                
                LobbyObjects[2].GetComponent<Image>().sprite = luxuryDesk;
                LobbyObjects[2].SetActive(true);
                LobbyObjects[1].GetComponent<Image>().sprite = luxuryAthena;
                LobbyObjects[1].SetActive(true);
                LobbyObjects[4].SetActive(false);
                LobbyObjects[5].SetActive(false);
                LobbyObjects[10].SetActive(true);                
                LobbyObjects[0].SetActive(false);                
                LobbyObjects[8].SetActive(true);

                //Add Luxury Sofa and Chandelier
                LobbyObjects[11].SetActive(true);
                LobbyObjects[9].SetActive(true);
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

            case 11:
                requiredMoney = 0;
                break;

            case 12:
                requiredMoney = 0;
                break;

            case 13:
                requiredMoney = 0;
                break;

            case 14:
                requiredMoney = 0;
                break;

            case 15:
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
            if(currentLevel < 15)
            {
                GameManager.main.lobbyLevel += 1;
                SetupLobby();
            }
            else
            {
                //If Lobby Level is 15 or higher print this.
                Debug.Log("You are max level");
            }
        }
    }

    public void OpenClientSelection()
    {
        if (clientSelectionPanel.activeSelf)
        {
            upgradeBtn.GetComponent<Button>().interactable = true;
            clientSelectionPanel.SetActive(false);
        }
        else
        {
            upgradeBtn.GetComponent<Button>().interactable = false;
            clientSelectionPanel.SetActive(true);
        }
    }

    public void OpenClientInfo()
    {
        
        if (infoPanel.activeSelf)
        {

            Debug.Log("Child Count: " + infoTraitPanel.transform.childCount);
            for(int i = 0; i < infoTraitPanel.transform.childCount; i++)
            {
                Destroy(infoTraitPanel.transform.GetChild(i).gameObject);
            }
    
            infoPanel.SetActive(false);
        }
        else
        {
            
            infoImage.sprite = sharkInfo.sharkSprite;
            infoName.text = sharkInfo.name;
            infoBio.text = sharkInfo.bio;
            GameObject tempTraitImage;
            for(int i = 0; i < sharkInfo.desiredTraits.Count; i++)
            {
                tempTraitImage = Instantiate(traitImage, infoTraitPanel.transform);
                tempTraitImage.GetComponent<Image>().sprite = sharkInfo.desiredTraits[i].traitSprite;
                
            }
            infoPanel.SetActive(true);
        }
    }

    public void SelectedClient()
    {
        if (infoPanel.activeSelf)
        {
            GameManager.main.selectedClient = sharkInfo;
            SceneManager.LoadScene(2);
            
        }
    }

}
