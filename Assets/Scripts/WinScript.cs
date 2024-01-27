using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Restart
    public void RestartGame()
    {
        //Change scene index to load based on scene's build index
        SceneManager.LoadSceneAsync(1);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
