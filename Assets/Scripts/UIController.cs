using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text waveInfoText;
    public GameObject levelCompleteScreen;
    public GameObject pauseScreen;
    
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Level Select");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Main Menu");
    }
    

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene("Main Menu");
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
