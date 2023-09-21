using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardAdButton : MonoBehaviour
{
    [SerializeField] Button button;
    private AdmobManager adManager;

    private void Start()
    {
        adManager = AdmobManager.instance;
        button.onClick.AddListener(adManager.ShowRewardedAd);
    }


}
