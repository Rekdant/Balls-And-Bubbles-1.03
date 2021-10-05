using System;

public class SpawnIntensityInTrainingModSlider : SliderBase
{
    private void Start()
    {
        SetStartingValue(ValueHalper.KeyIntensitySphereSpawnInTrainingMod, ValueHalper.DefaultIntensitySphereSpawnInTrainingMod);
    }

    protected override void OnSliderChangeValueHandler(float value)
    {
        SetValue(value, 1);
        SaveValue(ValueHalper.KeyIntensitySphereSpawnInTrainingMod, value, 1);
    }
}
