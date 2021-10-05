using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransitions : MonoBehaviour
{
    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }

    public void LoadScene(string name)
    {
        AudioPlayer.PlaySound(Sounds.Button);
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        AudioPlayer.PlaySound(Sounds.Button);
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }

    public void ExitFromGame()
    {
        AudioPlayer.PlaySound(Sounds.Button);
        Application.Quit();
    }
}
