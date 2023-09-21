using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
/*    [SerializeField] SettingsValuesSO settings;
    [SerializeField] string musicMuteSettingName, sfxMuteSettingName;*/
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingBar;
    private PlayerCoinManager playerCoinManager;
    private PlayerScoreManager playerScoreManager;


    private void Start()
    {
        playerCoinManager = FindObjectOfType<PlayerCoinManager>();
        playerScoreManager = FindObjectOfType<PlayerScoreManager>();
    }

    /*    private void Start()
        {
            for (int i = 0; i < settings.boolSettings.Length; i++)
            {
                if (settings.boolSettings[i].valueName == musicMuteSettingName)
                    settings.boolSettings[i].onSettingsChanges += UpdateMusicToggle;

                if (settings.boolSettings[i].valueName == sfxMuteSettingName)
                    settings.boolSettings[i].onSettingsChanges += UpdateSfxToggle;
            }
        }

        private void UpdateMusicToggle(bool mute)
        {
            // Update Sound Toggle
        }
        private void UpdateSfxToggle(bool mute)
        {
            // Update Sound Toggle
        }*/


    private IEnumerator LoadLevel(AsyncOperation loadingOperation)
    {
        if (playerScoreManager) playerScoreManager.UpdateScore();
        loadingScreen.SetActive(true);

        if (loadingBar) loadingBar.fillAmount = 0f;
        while (!loadingOperation.isDone)
        {
            if (loadingBar) loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, loadingOperation.progress, Time.deltaTime * 10f);
            yield return null;
        }
    }

    public void LoadNextLevel()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(loadingOperation));
    }

    public void LoadCurrentLevel()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadLevel(loadingOperation));
    }

    public void LoadLevelByIndex(int levelIndex)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(levelIndex);
        StartCoroutine(LoadLevel(loadingOperation));
    }

    public void LoadLevelByString(string levelName)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(levelName);
        StartCoroutine(LoadLevel(loadingOperation));
    }

    public static void ExitGame() => Application.Quit();

}
