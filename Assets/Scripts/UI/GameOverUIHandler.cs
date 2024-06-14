using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    public Button tryAgainButton;  
    public Button mainMenuButton;

    void Start()
    {
        tryAgainButton.onClick.AddListener(TryAgain);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
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
