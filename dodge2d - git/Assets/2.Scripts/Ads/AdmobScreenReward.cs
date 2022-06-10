using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobScreenReward : MonoBehaviour
{
    private RewardedInterstitialAd rewardedInterstitialAd;

    private string rewardID = "ca-app-pub-4697644976729834/7549911324";
    // 실제 광고 ID
    private string rewardTestID = "ca-app-pub-3940256099942544/5354046379";
    // 테스트 광고 ID, 지금은 테스트를 사용

    public AudioClip rewardCoinClip;
    private AudioSource rewardAudio;

    private int coin;
    public GameObject coinSet;

    private void Awake()
    {
        CreateAndLoadRewardedInterstitialAd();

        rewardAudio = GetComponent<AudioSource>();
        coin = PlayerPrefs.GetInt("Coin", 0);
    }


    private void adLoadCallback(RewardedInterstitialAd ad, string error)
    {
        if (error == null)
        {
            rewardedInterstitialAd = ad;
            
            rewardedInterstitialAd.OnAdDidDismissFullScreenContent += HandleAdDidDismiss;
            rewardedInterstitialAd.OnPaidEvent += HandlePaidEvent;
        }

        else
        {
            CreateAndLoadRewardedInterstitialAd();
        }
    }

    public void CreateAndLoadRewardedInterstitialAd() // 광고 다시 로드하는 함수
    {
        AdRequest request = new AdRequest.Builder().Build();

        RewardedInterstitialAd.LoadAd(rewardID, request, adLoadCallback);
    }


    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show(userEarnedRewardCallback);
        }

        else if (rewardedInterstitialAd == null)
        {
            AndroidSet.instance.ShowToast("Please try again Later");
            Invoke("CancelToast", 1f);
        }
    }

    private void userEarnedRewardCallback(Reward reward)
    {
        // TODO: Reward the user.
        StartCoroutine(rewardCoinPlus());
    }

    private void HandleAdDidDismiss(object sender, EventArgs args)
    {
        CreateAndLoadRewardedInterstitialAd();
    }

    private void HandlePaidEvent(object sender, AdValueEventArgs args)
    {
        CreateAndLoadRewardedInterstitialAd();
    }

    private void CancelToast()
    {
        AndroidSet.instance.CancelToast();
    }

    IEnumerator rewardCoinPlus()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        coin = coin + 5;
        PlayerPrefs.SetInt("Coin", coin);
        rewardAudio.PlayOneShot(rewardCoinClip);
        coinSet.SetActive(true);


        yield return new WaitForSeconds(0.5f);
        coinSet.SetActive(false);

    }


}
