using UnityEngine;
using DG.Tweening;
using System.Collections;

public class WindowAnimation : MonoBehaviour
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        yield return new WaitForEndOfFrame();
        _rect.DOScale(Vector2.one, 0.5f).From(Vector2.zero, true).SetEase(Ease.OutElastic).SetUpdate(UpdateType.Normal, true);
    }
}
