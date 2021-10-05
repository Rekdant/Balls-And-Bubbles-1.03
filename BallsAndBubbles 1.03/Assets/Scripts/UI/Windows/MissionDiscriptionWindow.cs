using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionDiscriptionWindow : MonoBehaviour
{
    [SerializeField] private RectTransform _window; 
    [SerializeField] private Button _closeWindowButton;
    [SerializeField] private TMP_Text _discriptionText;

    private MissionConditions MissionConditions
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }
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
        SetLevelDiscription();
        _window.gameObject.SetActive(true); 
    }

    private void RespondButtonsClick()
    {
        _closeWindowButton.onClick.AddListener(OnWindowCloseButtonClickHandler);
    }

    private void OnWindowCloseButtonClickHandler()
    {
        _window.gameObject.SetActive(false);
        AudioPlayer.PlaySound(Sounds.Button);
    }

    private void SetLevelDiscription()
    {
        MissionType missionType = MissionConditions.MissionType;

        switch (missionType)
        {
            case MissionType.DestroySpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> �������.";
                break;
            case MissionType.LifeTheTime:
                _discriptionText.text = $"�� ���������� � ������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ������.";
                break;
            case MissionType.DestroySpheresInTime:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> �������, �� ���� ��� ������� ������.";
                break;
            case MissionType.DestroyGreenSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ������� �������.";
                break;
            case MissionType.DestroyRedSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ������� �������.";
                break;
            case MissionType.DestroyBlueSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ����� �������.";
                break;
            case MissionType.DestroyYellowSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ������ �������.";
                break;
            case MissionType.DestroyWhiteSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ����� �������.";
                break;
            case MissionType.DestroyBlackSpheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> ������ �������.";
                break;
            case MissionType.DestroyMultycoloredSheres:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> �������, �������� ���� ����.";
                break;
            case MissionType.DestroySpheresStack:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.StacksForOneStarLevelComplite}</color>/<color=yellow>{MissionConditions.StacksForTwoStarsLevelComplite}</color>/<color=green>{MissionConditions.StacksForThreeStarsLevelComplite}</color> ������ �����.";
                break;
            case MissionType.DestroyFish:
                _discriptionText.text = $"���������� <color=red>{MissionConditions.ValueToOneStarLevelComplit}</color>/<color=yellow>{MissionConditions.ValueToTwoStarsLevelComplit}</color>/<color=green>{MissionConditions.ValueToThreeStarsLevelComplit}</color> �����.";
                break;
        }
    }
}
