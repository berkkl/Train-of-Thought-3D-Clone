using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    #region Singleton & Awake
    
    public static LevelManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region variables

    public bool isGameFinished = false;
    public bool isGamePaused = false;
    public int totalEntities;
    public int entitiesDestroyed = 0;
    public int entitiesRemaining;
    public int score;

    #endregion

    #region Methods

    public void EndGameSequence()
    {
        isGameFinished = true;
        Debug.Log("Your Score is: " + score + "/" + totalEntities);
        UIController.Instance.finalScoreText.text = "Total Entities: " + totalEntities + "\n" + "\n" + "Score: " + score;
        UIController.Instance.levelCompleteScreen.SetActive(true);
        
    }

    #endregion

    #region Start

    private void Start()
    {
        Time.timeScale = 1;
        UIController.Instance.levelCompleteScreen.SetActive(false);
    }

    #endregion


}
