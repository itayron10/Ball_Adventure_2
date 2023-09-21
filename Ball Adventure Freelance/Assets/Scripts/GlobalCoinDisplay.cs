using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class GlobalCoinDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] string massage;
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = SaveManager.instance;
    }

    private void Update()
    {
        coinText.text = $"{massage} {saveManager.globalCoinAmount}";
    }
}
