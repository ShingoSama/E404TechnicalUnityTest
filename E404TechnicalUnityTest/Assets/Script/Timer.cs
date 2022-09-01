using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minutes_total;
    [SerializeField]
    private int seconds_total;
    private int minutes_left, seconds_left;

    public TMP_Text textToFinish;
    public float secondsToFinish;
    // Start is called before the first frame update
    void Start()
    {
        textToFinish.text = secondsToFinish.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.instance.GetGameStatus())
        //{
        //    secondsToFinish = secondsToFinish - Time.deltaTime;
        //    textToFinish.text = secondsToFinish.ToString("F2");
        //    if (secondsToFinish < 0)
        //    {
        //        GameManager.instance.EndGame();
        //    }
        //}
        //if (GameManager.instance.gameStatus == GameManager.gameState.Menu)
        //{
        //    secondsToFinish = 60;
        //}
    }
    public void StartTimer()
    {

    }
    public void StopTimer()
    {

    }
    private void UpdateTimer()
    {
        if (seconds_left < 0)
        {

        }
    }
}