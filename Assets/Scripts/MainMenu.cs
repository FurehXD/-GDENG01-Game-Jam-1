using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip buttonSoundClip;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject settingsUI;


    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_PLAY_GAME, this.OnPlayGame);
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_SETTINGS, this.OnSettings);
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_QUIT_GAME, this.OnQuitGame);
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_BACK, this.OnBack);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_PLAY_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_SETTINGS);
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_QUIT_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_BACK);
    }

    private void playSFX_button()
    {
        SoundFXManager.Instance.PlaySoundFXClip(buttonSoundClip, transform, 1f); 
    }

    public void OnPlayGame()
    {
        this.playSFX_button();
        Debug.Log("Play game");
        LoadManager.Instance.LoadScene("GameScene");
    }

    public void OnSettings()
    {
        this.playSFX_button();
        Debug.Log("Settings");
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void OnQuitGame()
    {
        this.playSFX_button();
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void OnBack()
    {
        this.playSFX_button();
        menuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
}
