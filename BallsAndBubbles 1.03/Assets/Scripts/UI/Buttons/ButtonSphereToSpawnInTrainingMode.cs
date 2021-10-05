using UnityEngine;
using UnityEngine.UI;

public class ButtonSphereToSpawnInTrainingMode : MonoBehaviour
{
    [SerializeField] private SphereSpawnerInTrainingMod _sphereSpawner;
    [SerializeField] private Sphere _sphereToSpawn;
    [SerializeField] private Image _image;

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
        _button.onClick.AddListener(OnClickButtonHanler);
    }

    private void OnClickButtonHanler()
    {
        SetMark();
        AudioPlayer.PlaySound(Sounds.Button);
        _sphereSpawner.SetSphere(_sphereToSpawn);
    }

    private void SetMark()
    {
        if (_image.enabled == false)
        {
            _image.enabled = true;
        }
        else
        {
            _image.enabled = false;
        }
    }
}
