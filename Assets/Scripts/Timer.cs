using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerCoroutine(1));
    }

    IEnumerator TimerCoroutine(float step)
    {
        float timeInSeconds = 0;
        while (true)
        {
            yield return new WaitForSeconds(step);
            timeInSeconds += step;
            timerText.text = timeInSeconds.ToString();
        }
    }
}
