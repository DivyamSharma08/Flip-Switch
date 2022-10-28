using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
//    public Text adStatus;

    string App_Id = "ca-app-pub-9601525912442679~3459214383";
    string BannerId = "ca-app-pub-3940256099942544/6300978111";
    string InterstitialId = "ca-app-pub-3940256099942544/1033173712";
    string VideoId = "ca-app-pub-3940256099942544/5224354917";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    // Start is called before the first frame update

    void Start()
    {

        MobileAds.Initialize(App_Id);

    }
    
    public void RequestBanner()
    {
        // Create a 320x50 banner at the bottom of the screen.
        AdSize adsize = new AdSize(350,50);
        this.bannerView = new BannerView(BannerId, adsize, AdPosition.BottomLeft);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoadedBanner;
        // Called when an ad request failed to load.

        ShowBannerAd();
    }

    public void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    
    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(InterstitialId);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoadedInter;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoadInter;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RequestRewardBasedVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request, VideoId);
    }

    public void ShowVideoRewardAd()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
    }


    //For Events and Delegates for Ads

    #region BannerAds

    public void HandleOnAdLoadedBanner(object sender, EventArgs args)
    {
        ShowBannerAd();
    }

    public void HandleOnAdFailedToLoadBanner(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    #endregion

    #region InterstitialAds

    public void HandleOnAdLoadedInter(object sender, EventArgs args)
    {
        ShowInterstitialAd();
    }

    public void HandleOnAdFailedToLoadInter(object sender, AdFailedToLoadEventArgs args)
    {
        RequestInterstitial();
    }

    #endregion

    #region RewardAds

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        ShowVideoRewardAd();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("Ad Failed to Load");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    #endregion
}
