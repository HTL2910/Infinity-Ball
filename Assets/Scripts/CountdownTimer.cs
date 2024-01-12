using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float timerDuration = 600.0f; // 10 minutes in seconds
    private float currentTime;
    void Start()
    {
        currentTime = 0f;
        Time(currentTime, UIManger.Instance.timeText);
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (currentTime < timerDuration)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1.0f); // Update every second
            currentTime += 1.0f;
        }

        // Handle timer reaching 600 seconds (10 minutes)
        Debug.Log("Win!");
    }

    void UpdateTimerText()
    {
        Time(currentTime, UIManger.Instance.timeText);
       
        float maxTime = PlayerPrefs.GetFloat("maxTime", 0f);
        if(maxTime<currentTime)
        {
            PlayerPrefs.SetFloat("maxTime", currentTime);
        }   
        float newMaxtime = PlayerPrefs.GetFloat("maxTime", 0f);
        Time(newMaxtime, UIManger.Instance.timeTextDialogMax);
        Debug.Log(maxTime);
        Debug.Log(currentTime);
    }
    private void Time(float time,TextMeshProUGUI text)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        string minutesString = minutes.ToString("00");
        string secondsString = seconds.ToString("00");
        text.text = minutesString + ":" + secondsString;
    }
}
