using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minutes_total;
    [SerializeField]
    private int seconds_total;
    private int minutes_left, seconds_left;

    public TMP_Text textToFinish;

    public void StartTimer()
    {
        minutes_left = minutes_total;
        seconds_left = seconds_total;
        WriteTimer(minutes_left, seconds_left);
        Invoke("UpdateTimer", 1f);
    }
    public void StopTimer()
    {
        CancelInvoke();
    }
    private void UpdateTimer()
    {
        seconds_left--;
        if (seconds_left < 0)
        {
            if (minutes_left == 0 && GameManager.instance.GetPlayingState())
            {
                GameManager.instance.EndGame();
                return;
            }
            else
            {
                minutes_left--;
                seconds_left = 59;
            }
        }
        WriteTimer(minutes_left, seconds_left);
        Invoke("UpdateTimer", 1f);
    }
    private void WriteTimer(int min, int sec)
    {
        if (seconds_left<10)
        {
            textToFinish.text = minutes_left.ToString() + ":0" + seconds_left.ToString();
        }
        else
        {
            textToFinish.text = minutes_left.ToString() + ":" + seconds_left.ToString();
        }
    }
}