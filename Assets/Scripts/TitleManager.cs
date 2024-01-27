using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private GameObject creditsScreen;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenTitleScreen()
    {
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void OpenControlsScreen()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void OpenCreditsScreen()
    {
        titleScreen.SetActive(false);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
}
