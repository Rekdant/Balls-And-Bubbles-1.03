using TMPro;
using UnityEngine;
using DG.Tweening;

public abstract class UIPlayWindowInfo : MonoBehaviour
{
    private const float MaxTextScale = 1.5f;
    private const float MinTextScale = 1f;
    private const float AnimationTime = 0.2f;

    private TMP_Text _text;
    private int _previousValue;

    protected MissionConditions MissionConditions
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }

    protected void Awake()
    {
        Init();      
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void Init()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected abstract void SubscribeToEvents();

    protected abstract void UnsubscribeFromEvents();   

    protected virtual void DisplayInfo(int currentValue)
    {
        if (_previousValue == currentValue)
        {
            return;
        }
        else 
        {
            _previousValue = currentValue;
        }      

        if (currentValue >= MissionConditions.ValueToTwoStarsLevelComplit)
        {
            SetColor(Color.green);
            SetText($"{currentValue}/{ MissionConditions.ValueToThreeStarsLevelComplit}");
        }
        else if (currentValue >= MissionConditions.ValueToOneStarLevelComplit)
        {
            SetColor(Color.yellow);
            SetText($"{currentValue}/{ MissionConditions.ValueToTwoStarsLevelComplit}");
        }
        else
        {
            SetColor(Color.red);
            SetText($"{currentValue}/{ MissionConditions.ValueToOneStarLevelComplit}");
        }

        Animate();
    }

    protected void SetText(string text)
    {
        _text.text = text;
    }

    protected void SetColor(Color color)
    {
        _text.DOColor(color, 1);
    }

    protected void Animate()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(MaxTextScale, AnimationTime/2));
        sequence.Append(transform.DOScale(MinTextScale, AnimationTime/2));
    }
}
