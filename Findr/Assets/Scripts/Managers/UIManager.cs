using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Static Members

    public static UIManager main;

    #endregion

    #region Runtime Members

    [System.Serializable]
    public struct Screen
    {
        public string name;
        public GameObject screen;
    }

    public List<Screen> Screens = new List<Screen>();

    public AudioClip Confirm;
    public int CurrentScreen;
    public string PreviousScreenName = "None";
    //public GameObject CurrentLevel;

    #endregion

    #region MonoBehavior
    private void Awake()
    {
        if (main != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        main = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods

    public void ShowScreen(string name)
    {
        AudioManager.main.PlaySingle(AudioManager.main.Confirm);

        PreviousScreenName = Screens[CurrentScreen].name;
        for (int i = 0; i < Screens.Count; i++)
        {
            if (Screens[i].name.Equals(name))
            {
                Screens[CurrentScreen].screen.SetActive(false);
                Screens[i].screen.SetActive(true);
                CurrentScreen = i;
            }
        }
    }

    public void Quit()
    {
        AudioManager.main.PlaySingle(AudioManager.main.Confirm);
        Application.Quit();
    }

    public void PauseGame()
    {
        if (!GameManager.main.IsPaused)
        {
            Time.timeScale = 0;
            GameManager.main.IsPaused = true;
            PreviousScreenName = Screens[CurrentScreen].name;
            ShowScreen("Pause");
        }
        else
        {
            Time.timeScale = 1;
            GameManager.main.IsPaused = false;
            ShowScreen(PreviousScreenName);
        }
        
    }

    public void SettingsMenu()
    {
        ShowScreen("Settings");
    }

    public void BackToLobby()
    {
        PauseGame();
        AudioManager.main.PlayMusic(AudioManager.main.LobbyMusic);
        SceneManager.LoadScene("Lobby");
    }

    public void Play()
    {
        AudioManager.main.PlaySingle(AudioManager.main.Confirm);
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}