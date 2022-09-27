using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private void Start()
    {
        UIController.Instance.scoreText.text = "CORRECT: " + 
                                               LevelManager.Instance.score + "/" + 
                                               LevelManager.Instance.entitiesDestroyed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag(collision.gameObject.tag))
        {
            Destroy(collision.gameObject);
            LevelManager.Instance.score++;
            LevelManager.Instance.entitiesRemaining--;
            LevelManager.Instance.entitiesDestroyed++;
            
            UIController.Instance.scoreText.text = "CORRECT: " + 
                                                   LevelManager.Instance.score + "/" + 
                                                   LevelManager.Instance.entitiesDestroyed;

            UIController.Instance.waveInfoText.text = LevelManager.Instance.entitiesRemaining.ToString();
            
            if(LevelManager.Instance.entitiesRemaining == 0)
            {
                LevelManager.Instance.EndGameSequence();
            }
        }
        else
        {
            Destroy(collision.gameObject);
            LevelManager.Instance.entitiesRemaining--;
            LevelManager.Instance.entitiesDestroyed++;
            UIController.Instance.scoreText.text = "CORRECT: " + 
                                                   LevelManager.Instance.score + "/" + 
                                                   LevelManager.Instance.entitiesDestroyed;
            
            UIController.Instance.waveInfoText.text = LevelManager.Instance.entitiesRemaining.ToString();
            
            if(LevelManager.Instance.entitiesRemaining == 0)
            {
                LevelManager.Instance.EndGameSequence();
            }
        }
    }
}
