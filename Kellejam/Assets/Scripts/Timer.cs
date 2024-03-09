using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    private bool hasTimerExpired = false;

    public event Action OnTimerExpired;

    public void StartTimer()
    {
        timeIsRunning = true;
    }

    
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else if (!hasTimerExpired) 
            {
                
                hasTimerExpired = true; 
                timeIsRunning = false;
                timeRemaining = 0;
                if (OnTimerExpired != null)
                    OnTimerExpired.Invoke(); 
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);


    }
}
