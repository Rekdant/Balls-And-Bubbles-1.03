using System;
using System.Collections.Generic;
using UnityEngine; 

public enum Sounds
{
    //Game
    GameStart,
    GameWin,
    GameLose,
    //Prefabs
    BubbleExplosion,
    BubbleVFX,
    GreenSphereVFX,
    RedSphereVFX,
    YellowSphereVFX,
    BlueSphereVFX,
    WhiteSphereVFX,
    BlackSphereVFX,
    Teleportation,
    FishDestroy,
    //UI
    Button
}

public enum Musics
{
    MainMenu,
    Music_01,
    Music_02,
    Music_03,
    Music_04,
    Music_05,
    Music_06,
    Music_07,
    Music_08,
    Music_09,
    Music_10,
    Music_11
}

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private List<SoundData> _soundsList = new List<SoundData>();
    [SerializeField] private List<MusicData> _musicList = new List<MusicData>();

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<AudioPlayer>();
    }

    public void PlaySound(Sounds sounds)
    {
        var clip = GetSoundClip(sounds);
        _soundSource.PlayOneShot(clip);
    }

    public void PlayMusic(Musics music)
    {
        var clip = GetMusicClip(music);
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlayRandomMusic()
    {
        var clip = GetMusicClip(_musicList[UnityEngine.Random.Range(1, _musicList.Count)].Music);       
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void StopSFX()
    {
        _soundSource.Stop();        
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicSource.UnPause();
    }

    private AudioClip GetSoundClip(Sounds sounds)
    {
        var data = _soundsList.Find(Data => Data.Sound == sounds);
        return data?.Clip;
    }

    private AudioClip GetMusicClip(Musics music)
    {
        var data = _musicList.Find(Data => Data.Music == music);
        return data?.Clip;
    }
}

[Serializable]
public class SoundData
{
    public Sounds Sound;
    public AudioClip Clip;
}

[Serializable]
public class MusicData
{
    public Musics Music;
    public AudioClip Clip;
}
