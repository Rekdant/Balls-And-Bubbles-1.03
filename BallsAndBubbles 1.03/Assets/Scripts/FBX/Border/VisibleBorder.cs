using Game.Events;
using UnityEngine;
using DG.Tweening;

public class VisibleBorder : MonoBehaviour
{
    private const float ColorChangeTime = 0.5f;

    private MeshRenderer[] _meshRenderers;

    private void Awake()
    {
        Init();
        UnsubscribeFromEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void Init()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void SubscribeToEvents()
    {
        EventAggregator.Subscribe<BorderColorChangeEvent>(OnColorUpdateHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<BorderColorChangeEvent>(OnColorUpdateHandler);
    }

    private void OnColorUpdateHandler(object sender, BorderColorChangeEvent border)
    {
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.material.DOColor(border.Color, ColorChangeTime);
        }
    }
}
