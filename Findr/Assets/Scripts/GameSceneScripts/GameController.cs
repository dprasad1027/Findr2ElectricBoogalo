﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float timer;
    private float resetTimer = 60.0f;

    private int score;
    private int resetScore = 0;

    public GameObject traitImage;
    public GameObject clientTraitsPanel;
    
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();        
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
        }

        timeText.text = "Time: " + timer.ToString("N0");
        
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

        UpdateMatchee();
        SelectedClientTraits();
        

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
        int randomTraitCount = Random.Range(1, 5);

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
        matcheeName.text = matcheeName.text;
        matcheeBio.text = matcheeBio.text;

    }



    public void Like()
    {

    }

    public void Dislike()
    {

    }
}
