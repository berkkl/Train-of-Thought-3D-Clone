using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string levelToLoad;

    public void OpenScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
