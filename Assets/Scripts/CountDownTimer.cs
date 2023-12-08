using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 60.0f; // Set the initial countdown time in seconds
    public float currentTime;
    public Text countdownText; // Reference to a Text UI element to display the countdown
    public bool canRun = false;


    public void RestartTimer()
    {
        startTime = 60.0f;
        currentTime = startTime;
        countdownText.enabled = true;
    }

    private void Update()
    {
        if (currentTime > 0 && canRun)
        {
            countdownText.enabled = true;
            currentTime -= Time.deltaTime; // Decrement the timer by the time passed since the last frame
            UpdateTimerText();
        }
        else
        {
            currentTime = 0;
            if (canRun)
            {
                EndTimer();
            }

            // Handle the timer reaching zero (e.g., end the game, trigger an event, etc.)
        }
    }

    private void UpdateTimerText()
    {
        if (countdownText != null)
        {
            countdownText.text = Mathf.Ceil(currentTime).ToString();
        }
    }
    private void EndTimer()
    {
        canRun = false;
        countdownText.enabled = false;
        GameManager.instance.EndTurn();


    }
}
