using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "LockableItems/Skin")]
public class SkinSO : LockableItemSO
{
    [SerializeField] Sprite Sprite;

    public Sprite GetSprite => Sprite;
}
