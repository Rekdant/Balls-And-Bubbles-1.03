using Game.Events;
using UnityEngine.EventSystems;

public class CameraSlider : SliderBase
{
    private void Start()
    {
        SetStartingValue(ValueHalper.KeyCameraSize, ValueHalper.DefaultCameraSize);
    }

    protected override void OnSliderChangeValueHandler(float value)
    {
        SetValue(value, 1);
        SaveValue(ValueHalper.KeyCameraSize, value);       

        EventAggregator.Post(this, new CameraChangeSizeEvent { Value = value });
    }    
}
