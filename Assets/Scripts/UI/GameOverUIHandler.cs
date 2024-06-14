using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    public Button tryAgainButton;
    public Button mainMenuButton;

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.GameEvents.ON_TRY_AGAIN, this.TryAgain);
        EventBroadcaster.Instance.AddObserver(EventNames.GameEvents.ON_MAIN_MENU, this.GoToMainMenu);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameEvents.ON_TRY_AGAIN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.GameEvents.ON_MAIN_MENU);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
