using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("MainGameScene"); // Make sure "MainGameScene" matches the name of your game scene
    }

    public void OpenOptions()
    {
        // Open options menu
        SceneManager.LoadScene("SettingScene");
    }

    public void ExitGame()
    {
        // Exit the application
        Application.Quit();
    }
    public void OpenScore()
    {
        // Open score menu
        SceneManager.LoadScene("ScoresScene");
    }
    public void BackMenu()
    {
        // Open score menu
        SceneManager.LoadScene("ScreneScene");
    }
    public void BadEnding()
    {
        // Open score menu
        SceneManager.LoadScene("BadEndScene");
    }
}