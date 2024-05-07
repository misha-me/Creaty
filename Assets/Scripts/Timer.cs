using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        timerText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerCoroutine(1));
    }

    IEnumerator TimerCoroutine(int step)
    {
        int timeInSeconds = 0;
        while (!playerScript.gameOver)
        {
            yield return new WaitForSeconds(step);
            timeInSeconds += step;
            timerText.text = FormatTime(timeInSeconds);
        }
    }

    private string FormatTime(int timeSec)
    {
        int minutes = timeSec / 60;
        int seconds = timeSec % 60;

        string minutesString = minutes < 10? "0" + minutes : minutes.ToString();
        string secondsString = seconds < 10? "0" + seconds : seconds.ToString();

        string timeString = minutesString + " : " + secondsString;

        return timeString;
    }
}
