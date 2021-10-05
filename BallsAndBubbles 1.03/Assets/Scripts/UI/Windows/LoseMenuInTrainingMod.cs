using UnityEngine;
using TMPro;
using Game.Events;

public class LoseMenuInTrainingMod : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private RectTransform _loseWindow;

    private int _record;

    private void Awake()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TransferFilteredPlayerScoreEvent>(OnScoreInfoUpdateHandler);
        EventAggregator.Subscribe<GameLoseEvent>(OnGameLoseHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<TransferFilteredPlayerScoreEvent>(OnScoreInfoUpdateHandler);
        EventAggregator.Unsubscribe<GameLoseEvent>(OnGameLoseHandler);
    }

    private void OnScoreInfoUpdateHandler(object sender, TransferFilteredPlayerScoreEvent data)
    {
        UpdateScoreText(data.TotalScore);
        TryUpdateRecord(data.TotalScore);
    }

    private void OnGameLoseHandler(object sender, GameLoseEvent data)
    {
        _loseWindow.gameObject.SetActive(true);
    }

    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void TryUpdateRecord(int score)
    {
        _record = PlayerPrefs.GetInt(ValueHalper.KeyTrainingRecord, 0);       

        if (_record < score)
        {
            PlayerPrefs.SetInt(ValueHalper.KeyTrainingRecord, score);
        }

        _recordText.text = _record.ToString();
    }
}
