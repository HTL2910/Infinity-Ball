using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timerDuration = 600.0f; // 10 minutes in seconds
    private float currentTime;
    void Start()
    {
        currentTime = 0f;
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
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        string minutesString = minutes.ToString("00");
        string secondsString = seconds.ToString("00");

        timerText.text = minutesString + ":" + secondsString;
    }
}
