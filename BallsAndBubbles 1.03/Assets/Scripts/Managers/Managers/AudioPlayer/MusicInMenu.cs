using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicInMenu : MonoBehaviour
{
    private const string Menu = "Menu";
    private const string Settings = "Settings";
    private const string Levels = "Levels";
    private const string RemoveAd = "RemoveAd";
    private const string GameEnd = "GameEnd";

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case Menu:
                AudioPlayer.PlayMusic(Musics.MainMenu);
                break;
            case Settings:
                break;
            case Levels:
                break;
            case RemoveAd:
                break;
            case GameEnd:
                break;
            default:
                AudioPlayer.PlayRandomMusic();
                break;
        }
    }
}
