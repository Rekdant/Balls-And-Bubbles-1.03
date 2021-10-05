using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour
{
    private const string AdUnitId = "ca-app-pub-3940256099942544/5224354917";

    [SerializeField] private TMP_Text _textAdDisableStatus;

    private RewardedAd _rewardedAd;
    private Button _button;

    public static bool IsAdOff { get; private set; }

    private void Awake()
    {
        Init();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvemts();
    }

    private void Start()
    {
        UpdateAdStatus();
        LoadAd();
    }

    private void Init()
    {
        _rewardedAd = new RewardedAd(AdUnitId);
        _button = GetComponent<Button>();
    }

    private void SubscribeToEvents()
    {
        _button.onClick.AddListener(OnButtonClickHandler);
        _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void UnsubscribeFromEvemts()
    {
        _button.onClick.RemoveListener(OnButtonClickHandler);
        _rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    private void OnButtonClickHandler()
    {
        ShowAd();
    }

    private void UpdateAdStatus()
    {
        if (IsAdOff)
        {
            _textAdDisableStatus.text = "<color=green>Реклама отключена</color>";
        }
        else
        {
            _textAdDisableStatus.text = "<color=red>Реклама включена</color>";
        }
    }

    private void LoadAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(request);
    }

    private void ShowAd()
    {
        if (IsAdOff == false && _rewardedAd.IsLoaded())
        {
            _rewardedAd.Show();
        }       
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        IsAdOff = true;
        UpdateAdStatus();
    }
}
