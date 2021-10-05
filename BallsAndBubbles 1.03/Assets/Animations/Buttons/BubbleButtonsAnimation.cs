using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class BubbleButtonsAnimation : MonoBehaviour, IPointerDownHandler
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Animate();
    }

    private void Animate()
    {        
        _rect.DOShakeScale(0.4f, 0.3f).OnComplete(RestoreScale);       
    }

    private void RestoreScale()
    {
        _rect.localScale = Vector3.one;
    }
}
