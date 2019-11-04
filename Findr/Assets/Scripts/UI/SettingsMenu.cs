using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    #region Runtime Members

    public Sprite SFX_On;
    public Sprite SFX_Off;
    public Button SFX_Button;

    public Sprite BGM_On;
    public Sprite BGM_Off;
    public Button BGM_Button;

    private float SFX_Vol;
    private float BGM_Vol;

    #endregion

    #region MonoBehavior

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

    public void ToggleSFX()
    {
        AudioManager.main.Mixer.GetFloat("SfxVol", out SFX_Vol);
        if (SFX_Vol < 20)
        {
            AudioManager.main.Mixer.SetFloat("SfxVol", 20.0f);
            SFX_Button.image.sprite = SFX_On;
            AudioManager.main.PlaySingle(AudioManager.main.Confirm);
        }
        else
        {
            AudioManager.main.Mixer.SetFloat("SfxVol", -80.0f);
            SFX_Button.image.sprite = SFX_Off;
        }
    }

    public void ToggleBGM()
    {
        AudioManager.main.Mixer.GetFloat("BgmVol", out BGM_Vol);
        if (BGM_Vol < 0)
        {
            AudioManager.main.Mixer.SetFloat("BgmVol", 0.0f);
            BGM_Button.image.sprite = BGM_On;
        }
        else
        {
            AudioManager.main.Mixer.SetFloat("BgmVol", -80.0f);
            BGM_Button.image.sprite = BGM_Off;
        }

        AudioManager.main.PlaySingle(AudioManager.main.Confirm);
    }

    public void Back()
    {
        UIManager.main.ShowScreen("None");
    }

    #endregion
}
