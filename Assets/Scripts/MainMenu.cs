using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_PLAY_GAME, this.OnPlayGame);
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_HELP, this.OnHelp);
        EventBroadcaster.Instance.AddObserver(EventNames.MainMenuEvents.ON_QUIT_GAME, this.OnQuitGame);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_PLAY_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_HELP);
        EventBroadcaster.Instance.RemoveObserver(EventNames.MainMenuEvents.ON_QUIT_GAME);
    }

    public void OnPlayGame()
    {
        //Debug.Log("Hello World");
        LoadManager.Instance.LoadScene("GameScene");
    }

    public void OnHelp()
    {
        LoadManager.Instance.LoadScene("HelpScene");
    }

    public void OnQuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
