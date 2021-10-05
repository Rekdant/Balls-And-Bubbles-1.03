using UnityEngine;
using UnityEngine.UI;

public class EducationButton : MonoBehaviour
{
    [SerializeField] private GameObject _parent;

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
        _button.onClick.AddListener(OnButtonClickHandler);
    }

    private void OnButtonClickHandler()
    {
        AudioPlayer.PlaySound(Sounds.Button);
        _parent.SetActive(false);
    }
}
