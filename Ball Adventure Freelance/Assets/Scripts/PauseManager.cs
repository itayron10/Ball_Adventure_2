using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseParant;

    private void Start()
    {
        TogglePause(false);    
    }

    public void TogglePause(bool pause)
    {
        pauseParant.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }
}
