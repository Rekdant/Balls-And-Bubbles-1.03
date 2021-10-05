using UnityEngine;
using Game.Events;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    private Button _button;

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

    private void Awake()
    {
        Init();
        RespondButtonsClick();
    }

    private void Init()
    {
        _button = GetComponent<Button>();
    }

    private void RespondButtonsClick()
    {
        _button.onClick.AddListener(OnPauseButtonClickHandler);
    }

    public void OnPauseButtonClickHandler()
    {
        AudioPlayer.PlaySound(Sounds.Button);
        EventAggregator.Post(this, new GameChangePauseStateEvent { });
    }   
}
