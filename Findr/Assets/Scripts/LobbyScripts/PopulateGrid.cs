using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject clientBtn;
    public int numberToCreate;

    // Start is called before the first frame update
    void Start()
    {
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

}
