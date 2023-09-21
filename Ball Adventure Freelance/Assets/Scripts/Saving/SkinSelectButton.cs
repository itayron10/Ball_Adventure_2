using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinSelectButton : LockableItemSelectButton<SkinSO>
{
    [SerializeField] Image skinIcon;


    private void Update()
    {
        if (GetSelectedSkin == lockableItem)
        {
            skinIcon.color = Color.grey;
        }
        else
        {
            skinIcon.color = Color.white;
        }
    }

    private SkinSO GetSelectedSkin => saveManager.skinsData[saveManager.playerSkinIndex];

    protected override void FindPrivateObjects()
    {
        base.FindPrivateObjects();
        skinIcon.sprite = lockableItem.GetSprite;
    }

    protected override void FireItemAction()
    {
        base.FireItemAction();
        // selects the skin to be his main skin
        saveManager.playerSkinIndex = saveManager.skinsData.IndexOf(lockableItem);
    }


}
