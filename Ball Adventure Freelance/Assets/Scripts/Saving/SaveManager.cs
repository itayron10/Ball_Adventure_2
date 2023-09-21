using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public int globalCoinAmount, playerSkinIndex;
    public int numberOfLevelsPlayedBeforeAd;
    public List<LevelDataSO> levelsData;
    public List<SkinSO> skinsData;
    public bool sfxOn = true, musicOn = true;
    private bool loadedData;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
    }


    private void OnApplicationPause(bool pause)
    {
        if (!pause) { return; }
        SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        // save coins
        PlayerPrefs.SetInt("Coins", globalCoinAmount);

        // save levels highscore
        foreach (LevelDataSO levelData in levelsData)
        {
            PlayerPrefs.SetInt($"{levelData.GetName}_Highscore", levelData.highscore);
            PlayerPrefs.SetInt($"{levelData.GetName}_Unlocked", levelData.isUnlocked ? 1 : 0);
        }

        // save skins data
        PlayerPrefs.SetInt("SelectedSkinIndex", playerSkinIndex);
        foreach (SkinSO skinData in skinsData)
        {
            PlayerPrefs.SetInt($"{skinData.GetName}_Unlocked", skinData.isUnlocked ? 1 : 0);
        }

        // save settings
        PlayerPrefs.SetInt("Sfx_Mute", sfxOn ? 1 : 0);
        PlayerPrefs.SetInt("Music_Mute", musicOn ? 1 : 0);


        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        if (loadedData) { return; }
        // load coins
        globalCoinAmount = PlayerPrefs.GetInt("Coins", 0);

        //load level data
        foreach (LevelDataSO levelData in levelsData)
        {
            levelData.highscore = PlayerPrefs.GetInt($"{levelData.GetName}_Highscore", 0);
            levelData.isUnlocked = PlayerPrefs.GetInt($"{levelData.GetName}_Unlocked", 0) == 1;
        }

        // load skins data
        playerSkinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);
        foreach (SkinSO skinData in skinsData)
        {
            skinData.isUnlocked = PlayerPrefs.GetInt($"{skinData.GetName}_Unlocked", 0) == 1;
        }

        // load settings
        sfxOn = PlayerPrefs.GetInt("Sfx_Mute", 0) == 1;
        musicOn = PlayerPrefs.GetInt("Music_Mute", 0) == 1;
        loadedData = true;
    }

    public LevelDataSO GetCurrentLevelData()
    {
        foreach (LevelDataSO levelData in levelsData)
        {
            if (levelData.sceneName == SceneManager.GetActiveScene().name)
            {
                return levelData;
            }
        }

        return null;
    }

    public LevelDataSO GetLevelData(string sceneName)
    {
        foreach (LevelDataSO levelData in levelsData)
        {
            if (levelData.sceneName == sceneName)
            {
                return levelData;
            }
        }

        return null;
    }


    [ContextMenu("Reset Savings")]
    public void DestroySavings()
    {
        PlayerPrefs.SetFloat("Coins", 0);
        foreach (LevelDataSO levelData in levelsData)
        {
            PlayerPrefs.SetInt($"{levelData.GetName}_Highscore", 0);
            PlayerPrefs.SetInt($"{levelData.GetName}_Unlocked", levelData.isUnlocked ? 1 : 0);
        }
        PlayerPrefs.SetFloat("SelectedSkinIndex", 0);
    }

}
