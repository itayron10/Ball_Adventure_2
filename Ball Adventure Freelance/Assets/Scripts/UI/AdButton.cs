using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdButton : MonoBehaviour
{
    [SerializeField] RewardedAd rewardedAd;

    public void DisplayAd()
    {
        rewardedAd.LoadAd();
    }
}
