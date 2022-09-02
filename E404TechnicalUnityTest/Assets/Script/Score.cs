using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int totalScore;
    [SerializeField]
    private AudioSource addCoinSound;
    [SerializeField]
    private AudioSource decreaseCoinSound;
    public TMP_Text textTotalScore;
    public void StartScore()
    {
        totalScore = 0;
        WriteScore(totalScore);
    }
    public void AddScorePoints(int addscore)
    {
        totalScore += addscore;
        if (addscore > 0)
        {
            AddCoinSound();
        }
        else if (addscore < 0)
        {
            DecreaseCoinSound();
        }
        if (totalScore < 0)
        {
            totalScore = 0;
        }
        WriteScore(totalScore);
    }
    private void WriteScore(int total)
    {
        textTotalScore.text = totalScore.ToString();
    }
    private void AddCoinSound()
    {
        addCoinSound.Play();
    }
    private void DecreaseCoinSound()
    {
        decreaseCoinSound.Play();
    }
}