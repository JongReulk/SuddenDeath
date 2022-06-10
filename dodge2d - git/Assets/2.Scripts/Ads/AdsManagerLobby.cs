using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class AdsManagerLobby : MonoBehaviour
{
    private string rewardID = "ca-app-pub-4697644976729834/5860232543";
    // 실제 광고 ID
    private string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    // 테스트 광고 ID, 지금은 테스트를 사용

    private RewardedAd rewardedAd;
    

    private bool rewarded = false;
    
    

    void Start()
    {
        rewardedAd = new RewardedAd(rewardTestID);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request); // 광고 로드

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 사용자가 광고를 끝까지 시청했을 때
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        // 사용자가 광고를 중간에 닫았을 때

        UserChoseToWatchAd();
    }

    void Update()
    {
        if (rewarded)
        {
            

            rewarded = false;
        }
        
    }

    public void UserChoseToWatchAd()
    {
        if (rewardedAd.IsLoaded()) // 광고가 로드 되었을 때
        {
            rewardedAd.Show(); // 광고 보여주기
        }

        if (!rewardedAd.IsLoaded())
        {
            AndroidSet.instance.ShowToast("Please try again Later");
            Invoke("CancelToast", 1f);
        }
    }

    public void CreateAndLoadRewardedAd() // 광고 다시 로드하는 함수
    {
        rewardedAd = new RewardedAd(rewardTestID);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {  // 사용자가 광고를 닫았을 때
        CreateAndLoadRewardedAd();  // 광고 다시 로드
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {  // 광고를 다 봤을 때
        rewarded = true;
    }

    private void CancelToast()
    {
        AndroidSet.instance.CancelToast();
    }

    
}
