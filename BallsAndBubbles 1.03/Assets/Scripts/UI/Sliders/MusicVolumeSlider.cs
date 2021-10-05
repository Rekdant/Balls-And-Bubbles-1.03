public class MusicVolumeSlider : SliderBase
{
    private void Start()
    {
        SetStartingValue(ValueHalper.KeyMusicVolume, ValueHalper.DefaultMusicVolume);
    }

    protected override void OnSliderChangeValueHandler(float value)
    {
        SaveValue(ValueHalper.KeyMusicVolume, value);
        SetStartingValue(ValueHalper.KeyMusicVolume, ValueHalper.DefaultMusicVolume);
    }
}

