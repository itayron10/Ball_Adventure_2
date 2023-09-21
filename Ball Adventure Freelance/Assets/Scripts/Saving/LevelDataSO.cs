using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "LockableItems/LevelData")]
public class LevelDataSO : LockableItemSO
{
    public int highscore;
    public string sceneName;
}
