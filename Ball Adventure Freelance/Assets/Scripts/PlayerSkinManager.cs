using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerRenderer;

    private void Start()
    {
        SaveManager saveManager = SaveManager.instance;
        playerRenderer.sprite = saveManager.skinsData[saveManager.playerSkinIndex].GetSprite;
    }

}
