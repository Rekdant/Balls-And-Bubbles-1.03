using UnityEngine;
using GoogleMobileAds.Api;

public class InitializeAdMob : MonoBehaviour
{
    private static bool IsAdInitialized = false;

    public void Start()
    {
        if (IsAdInitialized == false)
        {
            MobileAds.Initialize(initStatus => { });
            IsAdInitialized = true;
        }        
    }
}
