using UnityEngine;
using UnityEngine.UI;

public class TeachingWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _window;
    [SerializeField] private Button _button;

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

    private void Awake()
    {
        RespondButtonsClick();
    }

    private void Start()
    {
        _window.gameObject.SetActive(true);
    }

    private void RespondButtonsClick()
    {
        _button.onClick.AddListener(OnWindowCloseButtonClickHandler);
    }

    private void OnWindowCloseButtonClickHandler()
    {
        AudioPlayer.PlaySound(Sounds.Button);
        _window.gameObject.SetActive(false);
    }
}
