using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float happiness;
    public float minWinScore = 5000;

    [Header("HUD and Pause")]
    [Tooltip("The Slider from the HUD.")]
    public Slider happinessBar;

    [Tooltip("The pause menu canvas.")]
    public Canvas pauseScreen;

    public Canvas loseScreen;

    public TextMeshProUGUI timer;

    private bool isPaused;
    [SerializeField] private int minutes;
    [SerializeField] private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        happiness = 0;
        happinessBar.maxValue = 20000;
        happinessBar.value = happiness;
        pauseScreen.enabled = false;
        loseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (minutes > 0 && seconds <= 0)
        {
            minutes--;
            seconds = 59;
        }
        else if (seconds <= 0 && happiness < minWinScore)
        {
            seconds = 0;
            LoseGame();
        }
        else
        {
            seconds -= Time.deltaTime;
            timer.text = minutes.ToString() + " : " + (int)seconds;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseMenu();
        }

        if (!isPaused)
        {
            // Win Condition
            if (happiness >= minWinScore)
            {
                Time.timeScale = 0;
                EndGame();
            }

            happinessBar.value = happiness;
        }
    }


    public void EndGame()
    {
        // win screen
        SceneManager.LoadScene("WinScene");
    }

    public void LoseGame()
    {
        loseScreen.enabled = true;
        Time.timeScale = 0;
    }


    public void PauseMenu()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseScreen.enabled = true;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseScreen.enabled = false;
        }
        pauseScreen.GetComponent<AudioSource>().Play();
    }

    public void QuitGame()
    {
        pauseScreen.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1;
        loseScreen.GetComponentInChildren<AudioSource>().Play();
        SceneManager.LoadSceneAsync(0);
    }
}
