using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataDifficulty;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private enum gameState
    {
        Menu,
        Playing,
        EndGame
    }
    private gameState gameStatus;
    private diffyculty gameDiffyculty;
    [SerializeField]
    private List<DataDifficulty> difficultyList;
    private Timer gameTimer;
    private Score gameScore;
    private Spawner gameSpawner;
    public GameObject panelGameUI;
    public GameObject panelEndGame;
    public GameObject difficultyToggle;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        gameStatus = gameState.Menu;
        gameDiffyculty = diffyculty.Easy;
        gameTimer = gameObject.GetComponentInChildren<Timer>();
        gameScore = gameObject.GetComponentInChildren<Score>();
        gameSpawner = gameObject.GetComponentInChildren<Spawner>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        gameStatus = gameState.Playing;
        gameTimer.StartTimer();
        gameScore.StartScore();
        foreach (DataDifficulty item in difficultyList)
        {
            if (item.Diffyculty == gameDiffyculty)
            {
                gameSpawner.SetDataDifficulty(item);
            }
        }
        gameSpawner.StartSpawner();
    }
    public void EndGame()
    {
        gameStatus = gameState.EndGame;
        gameTimer.StopTimer();
        gameSpawner.StopSpawner();
        panelGameUI.SetActive(!panelGameUI.active);
        panelEndGame.SetActive(!panelEndGame.active);
    }
    public void AddScore(int pointsWin)
    {
        gameScore.AddScorePoints(pointsWin);
    }
    public bool GetPlayingState()
    {
        return gameStatus == gameState.Playing;
    }
    public bool GetMenuState()
    {
        return gameStatus == gameState.Menu;
    }
    public bool GetEndGameState()
    {
        return gameStatus == gameState.EndGame;
    }
    public void SpawnCoins()
    {
        gameSpawner.SpawnCoinsInitialize();
    }
    #region Set Dificulty
    public void SetDifficultyEasy(bool isOn)
    {
        if (isOn)
        {
            gameDiffyculty = diffyculty.Easy;
        }
    }
    public void SetDifficultyMedium(bool isOn)
    {
        if (isOn)
        {
            gameDiffyculty = diffyculty.Medium;
        }
    }
    public void SetDifficultyHard(bool isOn)
    {
        if (isOn)
        {
            gameDiffyculty = diffyculty.Hard;
        }
    }
    #endregion
}