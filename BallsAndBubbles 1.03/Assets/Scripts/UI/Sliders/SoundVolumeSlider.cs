public class SoundVolumeSlider : SliderBase
{
    private void Start()
    {
        SetStartingValue(ValueHalper.KeySoundVolume, ValueHalper.DefaultSoundVolume);
    }

    protected override void OnSliderChangeValueHandler(float value)
    {
        SaveValue(ValueHalper.KeySoundVolume, value);
        SetStartingValue(ValueHalper.KeySoundVolume, ValueHalper.DefaultSoundVolume);
    }   
}
