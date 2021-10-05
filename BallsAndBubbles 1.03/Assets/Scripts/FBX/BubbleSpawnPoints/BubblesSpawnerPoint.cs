using UnityEngine;

public class BubblesSpawnerPoint : MonoBehaviour
{
    private const float convertToAudioVolumeСoefficient = 0.1f;

    private AudioSource _audio;
    private ParticleSystem _particle;

    private void Awake()
    {
        Init();       
    }

    private void Start()
    {
        GetSavedVolume();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
        _particle = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        _audio.Play();
        _particle.Play();
    }

    public void Stop()
    {
        _audio.Stop();
        _particle.Stop();
    }

    private void GetSavedVolume()
    {
        if (PlayerPrefs.HasKey(ValueHalper.KeySoundVolume))
        {           
            _audio.volume = PlayerPrefs.GetFloat(ValueHalper.KeySoundVolume) * convertToAudioVolumeСoefficient;
        }
    }
}
