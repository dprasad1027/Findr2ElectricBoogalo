using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager main;

    private void Awake()
    {
        if (main != null)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
        DontDestroyOnLoad(this);

    }

    public void Save()
    {
        PlayerPrefs.SetInt("Money", GameManager.main.money);
        PlayerPrefs.SetInt("LobbyLevel", GameManager.main.lobbyLevel);
        PlayerPrefs.SetString("TutorialPassed", GameManager.main.tutorialPassed.ToString());

        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            GameManager.main.money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            GameManager.main.money = 0;
        }

        if (PlayerPrefs.HasKey("LobbyLevel"))
        {
            GameManager.main.lobbyLevel = PlayerPrefs.GetInt("LobbyLevel");
        }
        else
        {
            GameManager.main.lobbyLevel = 1;
        }

        if (PlayerPrefs.HasKey("TutorialPassed"))
        {
            GameManager.main.tutorialPassed = PlayerPrefs.GetString("TutorialPassed");
        }
        else
        {
            GameManager.main.tutorialPassed = "false";
        }

    }
}
