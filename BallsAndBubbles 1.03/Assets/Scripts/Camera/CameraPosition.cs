using UnityEngine;
using DG.Tweening;
using Game.Events;

public class CameraPosition : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
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
        _camera = GetComponent<Camera>();
    }

    private void SubscribeToEvents()
    {
        EventAggregator.Subscribe<CameraShakeEvent>(OnCameraShakePositionHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<CameraShakeEvent>(OnCameraShakePositionHandler);
    }

    private void OnCameraShakePositionHandler(object sender, CameraShakeEvent camera)
    {
        _camera.DOShakePosition(0.5f, 1);
    }
}
