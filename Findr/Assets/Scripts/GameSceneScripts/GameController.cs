using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour
{

    public Image matcheeImage;
    public Text matcheeName;
    public Text matcheeBio;
    public GameObject matcheeTraits;

    public List<Trait> gameTraits = new List<Trait>();
    public List<Shark> sharks = new List<Shark>();

    public Text timeText;
    public Text scoreText;

    public int randomTraitCount = 2;

    private float timer;
    private float resetTimer = 30.0f;

    private int score;
    private int resetScore = 0;
    private int money = 0;   

    public GameObject traitImage;
    public GameObject clientTraitsPanel;
    public Text resultScore;
    public Text moneyText;
    public GameObject resultScreen;


    public List<Trait> matcheeTraitList = new List<Trait>();
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateScoreText();
    }

    private void UpdateTimer()
    {
        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            ScoreToMoney();           

            resultScore.text = "Score: " + score.ToString();
            moneyText.text = ": " + money.ToString();

            resultScreen.SetActive(true);
        }

        timeText.text = "Time: " + timer.ToString("N0");
        
    }

    public void ReturnToLobby()
    {
        //UIManager.main.PauseGame();

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

        //UIManager.main.PauseGame();

        GameManager.main.money += money;
        AudioManager.main.PlayMusic(AudioManager.main.LobbyMusic);
        SceneManager.LoadScene("Lobby");
    }

    private void UpdateScoreText()
    {
        if(timer > 0)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void Start()
    {
        timer = resetTimer;
        score = resetScore;
        resultScreen.SetActive(false);

        if(GameManager.main.selectedClient == null)
        {
            Debug.Log("Shark not found!. Returning to Title Screen!");
            AudioManager.main.PlayMusic(AudioManager.main.LobbyMusic);
            SceneManager.LoadScene(0);
        }
        

        SelectedClientTraits();
        UpdateMatchee();


    }

    private void SelectedClientTraits()
    {
        //Setup selected Client Traits
        GameObject tempTraitImage;
        Shark selectedShark = GameManager.main.selectedClient;
        for (int i = 0; i < selectedShark.desiredTraits.Count; i++)
        {
            tempTraitImage = Instantiate(traitImage, clientTraitsPanel.transform);
            tempTraitImage.GetComponent<Image>().sprite = selectedShark.desiredTraits[i].traitSprite;
        }
    }

    private void MatcheeClientTraits(Shark s)
    {
        GameObject tempTraitImage;        
        s.desiredTraits.Clear();
        //int randomTraitCount = Random.Range(3, 6);

        //Give sharks random traits
        for(int i = 0; i < randomTraitCount; i++)
        {
            Trait randomTrait = gameTraits[Random.Range(0, gameTraits.Count)];
            while (s.desiredTraits.Contains(randomTrait))
            {
                randomTrait = gameTraits[Random.Range(0, gameTraits.Count)];
            }

            s.desiredTraits.Add(randomTrait);
        }
        s.desiredTraits.Remove(null);

        //Setup Matchee Traits Panel
        for(int i = 0; i < s.desiredTraits.Count; i++)
        {
            tempTraitImage = Instantiate(traitImage,matcheeTraits.transform);
            tempTraitImage.GetComponent<Image>().sprite = s.desiredTraits[i].traitSprite;
        }

        matcheeTraitList = s.desiredTraits;

    }


    private void RemoveMatcheeTraits()
    {
        //Remove traits from matchee traits panel after Like/Dislike and score calculation
        for(int i = 0; i < matcheeTraits.transform.childCount; i++)
        {
            Destroy(matcheeTraits.transform.GetChild(i).gameObject);
        }
    }


    private void RemoveClientTraits()
    {
        //Remove traits from client traits panel when leaving GameScene.
        for(int i = 0; i < clientTraitsPanel.transform.childCount; i++)
        {
            Destroy(clientTraitsPanel.transform.GetChild(i).gameObject);
        }
    }

    private void UpdateMatchee()    
    {
        Shark shark = GameManager.main.selectedClient;
        Shark matcheeShark = sharks[Random.Range(0, sharks.Count)];
        while(matcheeShark == shark)
        {
            matcheeShark = sharks[Random.Range(0, sharks.Count)];
        }

        MatcheeClientTraits(matcheeShark);
        matcheeImage.sprite = matcheeShark.sharkSprite;
        matcheeName.text = matcheeShark.name;
        matcheeBio.text = matcheeShark.bio;

    }



    public void Like()
    {
        Shark client = GameManager.main.selectedClient;    

        foreach (Trait t in matcheeTraitList)
        {
            if (client.desiredTraits.Contains(t))
            {
                score += 100;
            }
            else
            {
                if (score - 50 >= 0)
                {
                    score -= 50;
                }
            }
        }

        RemoveMatcheeTraits();
        UpdateMatchee();
    }

    public void Dislike()
    {
        Shark client = GameManager.main.selectedClient;

        foreach (Trait t in matcheeTraitList)
        {
            /*if (!client.desiredTraits.Contains(t))
            {
                score += 100;
            }
            else
            {
                score -= 50;
            }*/
        }

        RemoveMatcheeTraits();
        UpdateMatchee();
    }

    public void ScoreToMoney()
    {
        money = score;
    }
}
