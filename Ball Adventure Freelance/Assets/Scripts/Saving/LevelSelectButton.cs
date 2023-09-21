using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectButton : LockableItemSelectButton<LevelDataSO>
{
    [SerializeField] TextMeshProUGUI highscoreText;
    private LevelManager levelManager;

    protected override void FindPrivateObjects()
    {
        base.FindPrivateObjects();
        levelManager = FindObjectOfType<LevelManager>();
        highscoreText.text = saveManager.GetLevelData(lockableItem.sceneName).highscore.ToString();
        
    }

    protected override void FireItemAction()
    {
        base.FireItemAction();
        levelManager.LoadLevelByString(lockableItem.sceneName);
    }
}
