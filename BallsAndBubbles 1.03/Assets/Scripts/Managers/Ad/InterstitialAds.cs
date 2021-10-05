using UnityEngine;
using GoogleMobileAds.Api;
using Game.Events;
using System;
using System.Collections;

public class InterstitialAds : MonoBehaviour
{
    private const string AdUnitId = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd _interstitial;

    private void Awake()
    {
        _interstitial = new InterstitialAd(AdUnitId);
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void Start()
    {
        LoadAd();
    }

    private void SubscribeToEvents()
    {
        EventAggregator.Subscribe<GameWinEvent>(OnGameWinHandler);
        EventAggregator.Subscribe<GameLoseEvent>(OnGameLoseHandler);

        _interstitial.OnAdClosed += HandleOnAdClosed;
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<GameWinEvent>(OnGameWinHandler);
        EventAggregator.Unsubscribe<GameLoseEvent>(OnGameLoseHandler);

        _interstitial.OnAdClosed -= HandleOnAdClosed;
    }    

    private void OnGameWinHandler(object sender, GameWinEvent gameWinEvent)
    {
        ShowAd();
    }

    private void OnGameLoseHandler(object sender, GameLoseEvent gameLoseEvent)
    {
        ShowAd();
    }

    private void LoadAd()
    {
        if (RewardedAds.IsAdOff == false)
        {
            AdRequest request = new AdRequest.Builder().Build();
            _interstitial.LoadAd(request);
        }      
    }

    public void ShowAd()
    {
        if (RewardedAds.IsAdOff == false)
        {
            _interstitial.Show();   
        }        
    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {        
        _interstitial.Destroy();
        StartCoroutine(StopTimeAfterCloseAd());
    }

    private IEnumerator StopTimeAfterCloseAd()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }
}
