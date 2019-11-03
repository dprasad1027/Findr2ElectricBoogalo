using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Static Members

    public static GameManager main;

    #endregion

    #region RuntimeMembers

    public int lobbyLevel = 1;
    public int money = 0;
    public bool IsPaused = false;

    public Shark selectedClient;

    #endregion

    #region MonoBehavior

    private void Awake()
    {
        if(main != null)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
        DontDestroyOnLoad(this);

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



    #endregion

    #region Private Methods



    #endregion
}
