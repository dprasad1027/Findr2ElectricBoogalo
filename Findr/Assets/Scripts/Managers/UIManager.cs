using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string PreviousScreenName = "Lobby";
    public GameObject CurrentLevel;

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
        AudioManager.main.PlaySingle(Confirm);

        PreviousScreenName = Screens[CurrentScreen].name;
        for (int i = 0; i < Screens.Count; i++)
        {
            if (Screens[i].name.Equals(name))
            {
                if (Screens[CurrentScreen].name != CurrentLevel.name)
                {
                    Screens[CurrentScreen].screen.SetActive(false);
                }
                Screens[i].screen.SetActive(true);
                CurrentScreen = i;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        //GameManager.main.IsPaused = true;

        ShowScreen("Pause");
    }

    #endregion
}