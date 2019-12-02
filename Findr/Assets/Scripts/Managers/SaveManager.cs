using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager main;

    public JsonData data;
    public SaveState state;
    public string path;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        main = this;
        JsonLoad();
        //Save();

        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    public void Start()
    {
        data = new JsonData(0, 1, false);

        path = Path.Combine(Application.persistentDataPath, "saved files", "save.json");
    }

    public void SerializeData()
    {
        string jsonDataString = JsonUtility.ToJson(state, true);

        File.WriteAllText(path, jsonDataString);
        Debug.Log(jsonDataString);
    }

    public void DeserializeData()
    {
        string loadedJsonDataString = File.ReadAllText(path);

        data = JsonUtility.FromJson<JsonData>(loadedJsonDataString);

        Debug.Log($"Money: {data.Money.ToString()} | Lobby Level: {data.LobbyLevel.ToString()} | Tutorial Passed: {data.TutorialPassed.ToString()}");
    }

    // Save whole state of SaveState script to PlayerPref
    public void XmlSave()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    // Load previous SaveState from PlayerPref
    public void JsonLoad()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            XmlSave();
            Debug.Log("No save file found, creating a new one!");
        }
    }

    [SerializeField]
    public class JsonData
    {
        public int Money = 50;
        public int LobbyLevel = 0;
        public bool TutorialPassed = true;

        public JsonData()
        {
            this.Money = 0;
            this.LobbyLevel = 0;
            this.TutorialPassed = false;
        }

        public JsonData(int Money, int LobbyLevel, bool TutorialPassed)
        {
            this.Money = Money;
            this.LobbyLevel = LobbyLevel;
            this.TutorialPassed = TutorialPassed;
        }
    }
    
}
