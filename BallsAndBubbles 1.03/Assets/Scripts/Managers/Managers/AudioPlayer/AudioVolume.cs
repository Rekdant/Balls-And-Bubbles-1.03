using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    private const float ConversionRatioToAudioVolumeValue = 0.1f;

    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    private void Start()
    {
        SetSavedValues(_soundSource, ValueHalper.KeySoundVolume, ValueHalper.DefaultSoundVolume);
        SetSavedValues(_musicSource, ValueHalper.KeyMusicVolume, ValueHalper.DefaultMusicVolume);
    }

    private void SetSavedValues(AudioSource audio, string key, int defaultValue)
    {
        if (PlayerPrefs.HasKey(key))
        {           
            audio.volume = PlayerPrefs.GetFloat(key) * ConversionRatioToAudioVolumeValue ;
        }
        else
        {
            audio.volume = defaultValue * ConversionRatioToAudioVolumeValue ;
        }       
    }
}
