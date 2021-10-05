using UnityEngine;
using UnityEngine.UI;

public class LevelsButtonsInLevelsScene : MonoBehaviour
{
    [SerializeField] private Sprite _levelBlocked;
    [SerializeField] private Sprite _levelUnblocked;
    [SerializeField] private Sprite _levelCompletedWithOneStar;
    [SerializeField] private Sprite _levelCompletedWithTwoStars;
    [SerializeField] private Sprite _levelCompletedWithThreeStars;

    private Button[] _levelButtons;
    private GameProgressData _gameProgressData;

    private GameProgress GameProgress 
    {
        get { return ServiceLocator.Resolve<GameProgress>(); }
    }  

    private void Start()
    {
        _gameProgressData = GameProgress.Load();
        UpdateLevelInfo();
    }

    private void UpdateLevelInfo()
    {
        _levelButtons = GetComponentsInChildren<Button>();

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (_gameProgressData.Levels.ContainsKey(_levelButtons[i].gameObject.name))
            {
                switch (_gameProgressData.Levels[_levelButtons[i].gameObject.name])
                {
                    case 1:
                        SetButtonParametar(_levelButtons[i], _levelCompletedWithOneStar, true);
                        break;
                    case 2:
                        SetButtonParametar(_levelButtons[i], _levelCompletedWithTwoStars, true);
                        break;
                    case 3:
                        SetButtonParametar(_levelButtons[i], _levelCompletedWithThreeStars, true);
                        break;
                }
            }
            else
            {
                SetButtonParametar(_levelButtons[i], _levelBlocked, false);
            }
        }

        if (_gameProgressData.Levels.Count < _levelButtons.Length)
        {
            SetButtonParametar(_levelButtons[_gameProgressData.Levels.Count], _levelUnblocked, true);
        }
    }

    private void SetButtonParametar(Button button, Sprite image, bool isEnable)
    {
        button.image.sprite = image;
        button.enabled = isEnable;
    }
}
