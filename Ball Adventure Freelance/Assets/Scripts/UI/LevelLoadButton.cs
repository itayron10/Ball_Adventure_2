using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoadButton : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    public void LoadCurrentLevel()
    {
        levelManager.LoadCurrentLevel();
    }

    public void LoadLevelIndex(int index)
    {
        levelManager.LoadLevelByIndex(index);
    }

    public void LoadLevelName(string name)
    {
        levelManager.LoadLevelByString(name);
    }

}
