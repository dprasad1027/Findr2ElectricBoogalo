using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject clientBtn;
    public int numberToCreate;
    public List<Shark> sharks = new List<Shark>();
    public List<Shark> usedSharks = new List<Shark>();

    // Start is called before the first frame update
    void Start()
    {
        if (usedSharks.Count > 0)
        {
         usedSharks.Clear();
        }
        GetRandomShark();

        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Populate()
    {
        GameObject newObj;

        for(int i = 0; i < numberToCreate; i++)
        {
            newObj = Instantiate(clientBtn, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV();
            
        }
    }


    private void GetRandomShark()
    {
        //Get a random shark
        Shark randomShark = sharks[Random.Range(0, sharks.Count)];

        Debug.Log("Random Shark's name: " + randomShark.name);

        //Loop until randomshark is not a duplicate.
        while (usedSharks.Contains(randomShark))
        {
           randomShark = sharks[Random.Range(0, sharks.Count)];
           Debug.Log("Random Shark's name: " + randomShark.name);
        }

        //Add random shark to the usedSharks List.
        usedSharks.Add(randomShark);

        //Return the image of random shark
        //return randomShark.sharkSprite;

    }

}
