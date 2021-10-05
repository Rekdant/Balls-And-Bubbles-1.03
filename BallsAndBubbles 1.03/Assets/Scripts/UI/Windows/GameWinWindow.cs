using Game.Events;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _window;
    [SerializeField] private TMP_Text _starsText;
    [SerializeField] private RectTransform _oneStar;
    [SerializeField] private RectTransform _twoStar;
    [SerializeField] private RectTransform _threeStar;
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
        EventAggregator.Subscribe<GameWinEvent>(OnGameWinHandler); ;
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<GameWinEvent>(OnGameWinHandler);
    }

    private void OnGameWinHandler(object sender, GameWinEvent gameWin)
    {
        _window.gameObject.SetActive(true);

        GameProgress.TrySave(SceneManager.GetActiveScene().name, gameWin.StarsAmaunt);
        _starsText.text = GameProgress.Load().Stars.ToString();

        AudioPlayer.StopMusic();
        AudioPlayer.PlaySound(Sounds.GameWin);

        switch (gameWin.StarsAmaunt)
        {
            case 1:
                _oneStar.gameObject.SetActive(true);
                break;
            case 2:
                _twoStar.gameObject.SetActive(true);
                break;
            case 3:
               _threeStar.gameObject.SetActive(true);
                break;
        }
    }
}
