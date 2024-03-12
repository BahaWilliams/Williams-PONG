using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditMenu;

    public void GithubButton()
    {
        Application.OpenURL("https://github.com/BahaWilliams");
    }

    public void LinkedInButton()
    {
        Application.OpenURL("https://www.linkedin.com/in/baha-williams-azael-tambunan-52b035296/");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CreditButton()
    {
        OpenCredits();
    }

    public void BackButton()
    {
        CloseCredits();
    }

    private void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    private void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
