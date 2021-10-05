using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections;

public class GameNameAnimation : MonoBehaviour
{
    private const float MinValueBallsRectMovePosition = -80;
    private const float MaxValueBallsRectMovePosition = 80;
    private const float MinValueBubblesRectMovePosition = -150;
    private const float MaxValueBubblesRectMovePosition = 150;

    private const float MinValueChangeColorInterval = 3;
    private const float MaxValueChangeColorInterval = 6;
    private const float ColorChangeTime = 2;

    [SerializeField] private RectTransform _ballsRect;
    [SerializeField] private RectTransform _bubblesRect;
    [SerializeField] private TMP_Text _ballsText;
    [SerializeField] private TMP_Text _bubblesText;

    private Color[] _colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow};

    private float ColorChangeInterval
    {
        get { return Random.Range(MinValueChangeColorInterval, MaxValueChangeColorInterval); }
    }

    private void Start()
    {      
        Move(_ballsRect, MaxValueBallsRectMovePosition, MinValueBallsRectMovePosition);
        Move(_bubblesRect, MinValueBubblesRectMovePosition, MaxValueBubblesRectMovePosition);
        StartCoroutine(RefreshColor());
    }

    private void Move(RectTransform rect, float startPosition, float EndPosition)
    {
        var Sequence = DOTween.Sequence();
        Sequence.Append(rect.DOAnchorPosX(startPosition, 3).SetEase(Ease.InOutQuad));
        Sequence.Append(rect.DOAnchorPosX(EndPosition, 3).SetEase(Ease.InOutQuad));
        Sequence.SetLoops(-1);
    }

    private IEnumerator RefreshColor()
    {
        while (true)
        {
            SetColor(_ballsText);
            SetColor(_bubblesText);
            yield return new WaitForSeconds(ColorChangeInterval);           
        }            
    }

    private void SetColor(TMP_Text text)
    {
        text.DOColor(_colors[Random.Range(0, _colors.Length)], ColorChangeTime);
    }
}
