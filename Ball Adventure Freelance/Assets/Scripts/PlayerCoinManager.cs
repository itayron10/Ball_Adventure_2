using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCoinManager : MonoBehaviour
{
    [SerializeField] int runCoinAmount;
    [SerializeField] string coinsPreAmountText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] PlayerDeathManager playerDeathManager;
    private SaveManager saveManager;
    public int GetRunAmount => runCoinAmount;

    private void Start()
    {
        playerDeathManager.onDeath += UpdateGlobalCoins;
        saveManager = SaveManager.instance;
    }

    private void OnDestroy()
    {
        playerDeathManager.onDeath -= UpdateGlobalCoins;
    }

    private void Update()
    {
        coinsText.text = $"{coinsPreAmountText} {runCoinAmount}";
    }

    public void UpdateGlobalCoins()
    {
        saveManager.globalCoinAmount += runCoinAmount;
    }

    public void AddCoinAmount(int amountToAdd)
    {
        runCoinAmount += amountToAdd;
    }


}
