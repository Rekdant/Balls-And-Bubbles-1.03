using UnityEngine;

public class MissionContainer : MonoBehaviour
{
    private IMission _imission;

    private MissionType MissionType
    {
        get { return ServiceLocator.Resolve<MissionConditions>().MissionType; }
    }

    private void Start()
    {
        InitMission();
    }

    private void OnDestroy()
    {
        _imission.UnsubscribeFromEvent();
    }

    private void InitMission()
    {
        switch (MissionType)
        {
            case MissionType.DestroySpheres:
                _imission = new MissionDestroySpheres();
                break;
            case MissionType.LifeTheTime:
                _imission = new MissionToLifeTime();
                break;
            case MissionType.DestroySpheresInTime:
                _imission = new MissionDestroySpheresInTime();
                break;
            case MissionType.DestroySpheresStack:
                _imission = new MissionDestroySpheresStack();
                break;
            case MissionType.Training:
                _imission = new MissionTraining();
                break;
            default:
                _imission = new MissionDestroySpecificObject();
                break;
        }

        _imission.SubscribeToEvent();
    }
}
