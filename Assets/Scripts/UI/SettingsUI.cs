using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    [Header("UI Sections")]
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject ControlsUI;
    [SerializeField] private GameObject AudioUI;

    [Header("SFX")]
    [SerializeField] private AudioClip buttonSoundClip;

    private bool isAtAudio = false;
    private bool isAtControls = false;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.SettingsEvents.ON_RESUME, this.OnBack);
        EventBroadcaster.Instance.AddObserver(EventNames.SettingsEvents.ON_CONTROLS, this.OnControls);
        EventBroadcaster.Instance.AddObserver(EventNames.SettingsEvents.ON_AUDIO, this.OnAudio);
        EventBroadcaster.Instance.AddObserver(EventNames.SettingsEvents.ON_EXIT, this.OnExit);
        EventBroadcaster.Instance.AddObserver(EventNames.SettingsEvents.ON_BACK, this.OnBack);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showCursor();
            MainUI.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SettingsEvents.ON_RESUME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SettingsEvents.ON_CONTROLS);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SettingsEvents.ON_AUDIO);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SettingsEvents.ON_EXIT);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SettingsEvents.ON_BACK);
    }

    private void playSFX_button()
    {
        SoundFXManager.Instance.PlaySFXClip(buttonSoundClip, transform, 1f);
    }

    private void showCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void hideCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnResume()
    {
        playSFX_button();
        hideCursor();
        MainUI.SetActive(false);
    }

    public void OnControls()
    {
        playSFX_button();
        MainUI.SetActive(false);
        ControlsUI.SetActive(true);
        this.isAtControls = true;
        
    }

    public void OnAudio()
    {
        playSFX_button();
        MainUI.SetActive(false);
        AudioUI.SetActive(true);
        this.isAtAudio = true;
    }

    public void OnExit()
    {
        playSFX_button();
        LoadManager.Instance.LoadScene("MainMenuScene");
        
    }

    public void OnBack()
    {
        playSFX_button();

        if (isAtAudio)
        {
            AudioUI.SetActive(false);
            isAtAudio = false;
        }

        else if (isAtControls)
        {
            ControlsUI.SetActive(false);
            isAtControls = false;
        }

        MainUI.SetActive(true);

        
    }


}
