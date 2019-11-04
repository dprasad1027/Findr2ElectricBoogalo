using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject clientBtn;
    public List<Shark> sharks = new List<Shark>();
    public List<Shark> usedSharks = new List<Shark>(1);

    private int numberToCreate = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToCreate; i++)
        {
            GetRandomShark();
        }
        usedSharks.Remove(null);
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate()
    {
        GameObject newShark;
        
        if (LobbyManager.sharksToPopulate != numberToCreate)
        {
            numberToCreate = LobbyManager.sharksToPopulate;

            for (int i = 0; i < numberToCreate; i++)
            {
                GetRandomShark();
            }
            usedSharks.Remove(null);

        }

        for (int i = 0; i < numberToCreate; i++)
        {
            newShark = Instantiate(clientBtn, transform);
            newShark.GetComponent<Image>().sprite = usedSharks[i].sharkSprite;
            newShark.GetComponent<ClientInfo>().clientRef = usedSharks[i];
            
        }
    }


    private void GetRandomShark()
    {
        
        
        Debug.Log("UsedSharks Capacity: " + usedSharks.Capacity);             
        Shark randomShark = sharks[Random.Range(0, sharks.Count)];
        while (usedSharks.Contains(randomShark))
        {
            randomShark = sharks[Random.Range(0, sharks.Count)];
        }
        usedSharks.Add(randomShark);

    }

}
