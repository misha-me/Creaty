using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] GameObject content;
    public TextMeshProUGUI totalTimeText;

    private void Start()
    {
        CloseWindow();
    }

    public void OpenWindow()
    {
        content.SetActive(true);
        totalTimeText.text = "YOUR TIME: " + FindObjectOfType<Timer>().timerText.text;
    }

    public void CloseWindow()
    {
        content.SetActive(false);
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }

    public void ReplayButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
