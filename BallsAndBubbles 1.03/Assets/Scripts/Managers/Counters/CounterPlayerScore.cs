using Game.Events;
using System.Collections;
using UnityEngine;

public class CounterPlayerScore : MonoBehaviour
{   
    private int _totalSphereScore = 0;
    private int _greenSpheresScore = 0;
    private int _redSpheresScore = 0;
    private int _blueSpheresScore = 0;
    private int _yellowSpheresScore = 0;
    private int _whiteSpheresScore = 0;
    private int _blackSphereScore = 0;
    private int _multicoloredSphereScore = 0;
    private int _fishScore = 0;

    private void Awake()
    {
        SubscribeToEvent();
    }

    private void OnDestroy()
    {
        UnSubscribeFromEvent();
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        PostScoreData();
    }

    private void SubscribeToEvent()
    {       
        EventAggregator.Subscribe<SphereAddGreenSphereScoreEvent>(OnGreenSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddRedSphereScoreEvent>(OnRedSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddBlueSphereScoreEvent>(OnBlueSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddYellowSphereScoreEvent>(OnYellowSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddWhiteSphereScoreEvent>(OnWhiteSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddBlackSphereScoreEvent>(OnBlackSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<SphereAddMulticoloredSphereScoreEvent>(OnMulticoloredSphereEnlargeScoreHandler);
        EventAggregator.Subscribe<FishDestroyEvent>(OnFishEnlargeScoreHandler);
    }

    private void UnSubscribeFromEvent()
    {        
        EventAggregator.Unsubscribe<SphereAddGreenSphereScoreEvent>(OnGreenSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddRedSphereScoreEvent>(OnRedSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddBlueSphereScoreEvent>(OnBlueSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddYellowSphereScoreEvent>(OnYellowSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddWhiteSphereScoreEvent>(OnWhiteSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddBlackSphereScoreEvent>(OnBlackSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<SphereAddMulticoloredSphereScoreEvent>(OnMulticoloredSphereEnlargeScoreHandler);
        EventAggregator.Unsubscribe<FishDestroyEvent>(OnFishEnlargeScoreHandler);
    }

    private void OnGreenSphereEnlargeScoreHandler(object sender, SphereAddGreenSphereScoreEvent _) => UpdateScore(ref _greenSpheresScore);

    private void OnRedSphereEnlargeScoreHandler(object sender, SphereAddRedSphereScoreEvent _) => UpdateScore(ref _redSpheresScore);

    private void OnBlueSphereEnlargeScoreHandler(object sender, SphereAddBlueSphereScoreEvent _) => UpdateScore(ref _blueSpheresScore);

    private void OnYellowSphereEnlargeScoreHandler(object sender, SphereAddYellowSphereScoreEvent _) => UpdateScore(ref _yellowSpheresScore);

    private void OnWhiteSphereEnlargeScoreHandler(object sender, SphereAddWhiteSphereScoreEvent _) => UpdateScore(ref _whiteSpheresScore);

    private void OnBlackSphereEnlargeScoreHandler(object sender, SphereAddBlackSphereScoreEvent _) => UpdateScore(ref _blackSphereScore);

    private void OnMulticoloredSphereEnlargeScoreHandler(object sender, SphereAddMulticoloredSphereScoreEvent _) => UpdateScore(ref _multicoloredSphereScore);

    private void OnFishEnlargeScoreHandler(object sender, FishDestroyEvent _) => UpdateScore(ref _fishScore);

    private void UpdateScore(ref int currentItemScore)
    {       
        _totalSphereScore++;
        currentItemScore++;
        PostScoreData();
    }

    private void PostScoreData()
    {
        EventAggregator.Post(this, new TransferFilteredPlayerScoreEvent()
        {
            TotalScore = _totalSphereScore,
            GreenSphereScore = _greenSpheresScore,
            RedSphereScore = _redSpheresScore,
            BlueSphereScore = _blueSpheresScore,
            YellowSphereScore = _yellowSpheresScore,
            WhiteSphereScore = _whiteSpheresScore,
            BlackSphereScore = _blackSphereScore,
            MultycoloredSheres = _multicoloredSphereScore,
            FishScore = _fishScore
        }); ;
    }
}