using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private const string SaveKey = "SaveData";

    private string _json;
    private GameProgressData _gameProgressData;

    private void Awake()
    {
        ServiceLocator.Register(this);      
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<GameProgress>();
    }

    private void Start()
    {
        _gameProgressData = Load();
    }

    public GameProgressData Load()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            _json = PlayerPrefs.GetString(SaveKey);
            return JsonConvert.DeserializeObject<GameProgressData>(_json);
        }
        else
        {
            return new GameProgressData();
        }
    }

    public void TrySave(string levelName, int starsNumber)
    {
        if (_gameProgressData.Levels.ContainsKey(levelName))
        {
            int savedLevelStars = _gameProgressData.Levels[levelName];
            
            if (savedLevelStars < starsNumber)
            {               
                _gameProgressData.Levels.Remove(levelName);
                Save(levelName, starsNumber, savedLevelStars);
            }            
        }
        else
        {
            Save(levelName, starsNumber);
        }
    }   

    private void Save(string levelName, int starsNumber, int savedLevelStars = 0)
    {
        _gameProgressData.Levels.Add(levelName, starsNumber);
        _gameProgressData.Stars += starsNumber - savedLevelStars;

        _json = JsonConvert.SerializeObject(_gameProgressData);
        PlayerPrefs.SetString(SaveKey, _json);
    }   

    [ContextMenu("Delete")]
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}

public class GameProgressData
{
    public int Stars;
    public Dictionary<string, int> Levels = new Dictionary<string, int>();
}
