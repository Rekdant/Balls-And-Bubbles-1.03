using Game.Events;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _pauseMenu;

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
        EventAggregator.Subscribe<GameChangePauseStateEvent>(OnPauseChangeStateHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<GameChangePauseStateEvent>(OnPauseChangeStateHandler);
    }

    private void OnPauseChangeStateHandler(object sender, GameChangePauseStateEvent pauseState)
    {
        if (_pauseMenu.gameObject.activeInHierarchy)
        {
            AudioPlayer.UnPauseMusic();
            _pauseMenu.gameObject.SetActive(false);
        }
        else
        {
            AudioPlayer.PauseMusic();
            _pauseMenu.gameObject.SetActive(true);
        }
    }
}
