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
    [SerializeField] private AudioSource audioSource;

    public void StartGame()
    {
        audioSource.Play();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }

    public void OpenTitleScreen()
    {
        audioSource.Play();
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void OpenControlsScreen()
    {
        audioSource.Play();
        titleScreen.SetActive(false);
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void OpenCreditsScreen()
    {
        audioSource.Play();
        titleScreen.SetActive(false);
        controlsScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
}
