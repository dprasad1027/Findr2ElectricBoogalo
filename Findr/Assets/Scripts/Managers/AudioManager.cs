using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Static Members

    public static AudioManager main;

    #endregion

    #region RunTime Members

    public AudioMixer Mixer;

    public AudioSource FxSource;
    public AudioSource MusicSource;

    public AudioClip LobbyMusic;
    public AudioClip GameMusic;
    public AudioClip Confirm;

    private string SceneName = "";

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

    public void PlaySingle(AudioClip clip)
    {
        FxSource.clip = clip;
        FxSource.PlayOneShot(clip, 0.2f);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    #endregion
}
