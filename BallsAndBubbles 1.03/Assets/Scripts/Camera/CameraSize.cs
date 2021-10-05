using UnityEngine;
using Game.Events;

public class CameraSize : MonoBehaviour
{
    private const float MinSize = 7;
    private const float DefaultValue = 1;

    private Camera _camera;

    private void Awake()
    {
        Init();
        SubscribeToEvent();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvent();
    }

    private void Start()
    {
        SetStartedValue();
    }

    private void Init()
    {
        _camera = GetComponent<Camera>();
    }

    private void SubscribeToEvent()
    {
        EventAggregator.Subscribe<CameraChangeSizeEvent>(OnCameraChangeSizeHandler);
    }

    private void UnsubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<CameraChangeSizeEvent>(OnCameraChangeSizeHandler);
    }

    private void SetStartedValue()
    {
        if (PlayerPrefs.HasKey(ValueHalper.KeyCameraSize))
        {
            SetValue(PlayerPrefs.GetFloat(ValueHalper.KeyCameraSize));
        }
        else
        {
            SetValue(DefaultValue);
        }
    }

    private void OnCameraChangeSizeHandler(object sender, CameraChangeSizeEvent cameraSlider)
    {
        SetValue(cameraSlider.Value);
    }  

    private void SetValue(float value)
    {
        _camera.orthographicSize = value + MinSize;
    }
}
