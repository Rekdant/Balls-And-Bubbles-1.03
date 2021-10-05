using UnityEngine;

public enum MissionType
{
    DestroySpheres,
    LifeTheTime,
    DestroySpheresInTime,
    DestroyGreenSpheres,
    DestroyRedSpheres,
    DestroyBlueSpheres,
    DestroyYellowSpheres,   
    DestroyWhiteSpheres,
    DestroyBlackSpheres,
    DestroySpheresStack,
    DestroyMultycoloredSheres,
    DestroyFish,
    Training
}

public enum ExecutionStatus
{
    NullStars,
    OneStar,
    TwoStars,
    ThreeStars,
}

public class MissionConditions : MonoBehaviour
{
    [SerializeField] private MissionType _missionType;
    [SerializeField] private int _valueToOneStarLevelComplite;
    [SerializeField] private int _valueToTwoStarsLevelComplite;
    [SerializeField] private int _valueToThreeStarsLevelComplite;
    [SerializeField] private int _maxSpheresByScene;
    [Header("DestroySpheresInTime mod")]
    [SerializeField] private int _startTime;
    [SerializeField] private float _addedTime;
    [Header("DestroySpheresStack mod")]
    [SerializeField] private int _stacksForOneStarLevelComplite;
    [SerializeField] private int _stacksForTwoStarLevelComplite;
    [SerializeField] private int _stacksForThreeStarLevelComplite;

    public MissionType MissionType => _missionType;
    public int ValueToOneStarLevelComplit => _valueToOneStarLevelComplite;
    public int ValueToTwoStarsLevelComplit => _valueToTwoStarsLevelComplite;
    public int ValueToThreeStarsLevelComplit => _valueToThreeStarsLevelComplite;
    public int MaxSpheresByScene => _maxSpheresByScene;
    public int StartTime => _startTime;
    public float AddedTime => _addedTime;
    public int StacksForOneStarLevelComplite => _stacksForOneStarLevelComplite;
    public int StacksForTwoStarsLevelComplite => _stacksForTwoStarLevelComplite;
    public int StacksForThreeStarsLevelComplite => _stacksForThreeStarLevelComplite;

    private void OnValidate()
    {
        _valueToOneStarLevelComplite = Mathf.Abs(_valueToOneStarLevelComplite);
        _valueToTwoStarsLevelComplite = Mathf.Abs(_valueToTwoStarsLevelComplite);
        _valueToThreeStarsLevelComplite = Mathf.Abs(_valueToThreeStarsLevelComplite);
        _valueToTwoStarsLevelComplite = Mathf.Clamp(_valueToTwoStarsLevelComplite, _valueToOneStarLevelComplite, int.MaxValue);
        _valueToThreeStarsLevelComplite = Mathf.Clamp(_valueToThreeStarsLevelComplite, _valueToTwoStarsLevelComplite, int.MaxValue);

        _maxSpheresByScene = Mathf.Abs(_maxSpheresByScene);

        _startTime = Mathf.Abs(_startTime);
        _addedTime = Mathf.Abs(_addedTime);

        _stacksForOneStarLevelComplite = Mathf.Abs(_stacksForOneStarLevelComplite);
        _stacksForTwoStarLevelComplite = Mathf.Abs(_stacksForTwoStarLevelComplite);
        _stacksForThreeStarLevelComplite = Mathf.Abs(_stacksForThreeStarLevelComplite);
        _stacksForTwoStarLevelComplite = Mathf.Clamp(_stacksForTwoStarLevelComplite, _stacksForOneStarLevelComplite, int.MaxValue);
        _stacksForThreeStarLevelComplite = Mathf.Clamp(_stacksForThreeStarLevelComplite, _stacksForTwoStarLevelComplite, int.MaxValue);
    }

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<MissionConditions>();
    }   

    public ExecutionStatus GetExecutionStation(int currentValue)
    {
        if (IsLevelCompleteByOneStar(currentValue))
            return ExecutionStatus.OneStar;
        else if (IsLevelCompleteByTwoStars(currentValue))
            return ExecutionStatus.TwoStars;
        else if (IsLevelCompleteByThreeStars(currentValue))
            return ExecutionStatus.ThreeStars;
        else
            return ExecutionStatus.NullStars;
    }

    private bool IsLevelCompleteByOneStar(int scoreValue)
    {
        return scoreValue >= _valueToOneStarLevelComplite && scoreValue < _valueToTwoStarsLevelComplite;
    }

    private bool IsLevelCompleteByTwoStars(int scoreValue)
    {
        return scoreValue >= _valueToTwoStarsLevelComplite && scoreValue < _valueToThreeStarsLevelComplite;
    }

    private bool IsLevelCompleteByThreeStars(int scoreValue)
    {
        return scoreValue >= _valueToThreeStarsLevelComplite;
    }
} 


