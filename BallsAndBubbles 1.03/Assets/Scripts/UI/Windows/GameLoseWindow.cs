using UnityEngine;
using Game.Events;
using TMPro;

public class GameLoseWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _window;
    [SerializeField] private TMP_Text _starsText;

    private GameProgress GameProgress
    {
        get { return ServiceLocator.Resolve<GameProgress>(); }
    }
    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

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
        EventAggregator.Subscribe<GameLoseEvent>(OnGameLoseHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<GameLoseEvent>(OnGameLoseHandler);
    }

    private void OnGameLoseHandler(object sender, GameLoseEvent gameLose)
    {
        _window.gameObject.SetActive(true);
        _starsText.text = GameProgress.Load().Stars.ToString();

        AudioPlayer.StopMusic();
        AudioPlayer.PlaySound(Sounds.GameLose);
    }    
}
