using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockableItemSelectButton<T> : MonoBehaviour where T : LockableItemSO
{
    [SerializeField] protected T lockableItem;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] List<GameObject> hideOnUnlock;
    [SerializeField] List<GameObject> showOnUnlock;
    protected SaveManager saveManager;

    private void Start()
    {
        FindPrivateObjects();
    }

    protected virtual void FindPrivateObjects()
    {
        costText.text = lockableItem.GetCost.ToString();
        saveManager = SaveManager.instance;
        CheckForObjectsOnUnlock(lockableItem.isUnlocked);
    }

    protected virtual void FireItemAction()
    {
        // fire when the item is unlocked and the player pressed on it
    }
    public void SelectItem()
    {
        // Sound and effects for each action
        if (lockableItem.isUnlocked)
        {
            FireItemAction();
        }
        else if (saveManager.globalCoinAmount >= lockableItem.GetCost)
        {
            // unlocks the item
            lockableItem.isUnlocked = true;
            CheckForObjectsOnUnlock(true);
            saveManager.globalCoinAmount -= lockableItem.GetCost;
        }
        else
        {
            // cant unlock
            //Debug.Log("Not enogh money");
        }
    }

    private void CheckForObjectsOnUnlock(bool unlocked)
    {
        if (hideOnUnlock.Count > 0) foreach (var gameobject in hideOnUnlock) gameobject.SetActive(!unlocked);
        if (showOnUnlock.Count > 0) foreach (var gameobject in showOnUnlock) gameobject.SetActive(unlocked);
    }

}
