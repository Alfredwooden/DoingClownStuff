using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float happiness;

    [Header("HUD and Pause")]
    [Tooltip("The Slider from the HUD.")]
    public Slider happinessBar;

    [Tooltip("The pause menu canvas.")]
    public Canvas pauseScreen;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        happiness = 0;
        happinessBar.maxValue = 100;
        happinessBar.value = happiness;
        pauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                happiness += 10;
            }

            // Win Condition
            if (happiness >= 100)
            {
                Time.timeScale = 0;
                Debug.Log("You Win");
            }

            happinessBar.value = happiness;
        }
    }


    public void PauseMenu()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseScreen.enabled = true;
        } else
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseScreen.enabled = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
