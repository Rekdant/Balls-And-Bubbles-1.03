using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private int _necessaryFishAmountInScene;
    [SerializeField] private int _fishSpawnInterval;
    [SerializeField] private List<Fish> _fishes;

    private GameObjectsFolder GameObjectsFolder
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private int CurrentFishNumberInScene
    {
        get { return FindObjectsOfType<Fish>().Count(); }
    }
    private Fish RandomFish
    {
        get { return _fishes[Random.Range(0, _fishes.Count)]; }
    }
    private Vector2 SpawnPoint
    {
        get { return new Vector2(0, ValueHalper.PlaySpacePositionYaxisMax); }
    }

    private void OnValidate()
    {
        _necessaryFishAmountInScene = Mathf.Abs(_necessaryFishAmountInScene);
        _fishSpawnInterval = Mathf.Abs(_fishSpawnInterval);
    }

    private void Start()
    {      
        StartCoroutine(TrySpawnFish());
    }

    private IEnumerator TrySpawnFish()
    {
        while (true)
        {
            yield return new WaitForSeconds(_fishSpawnInterval);

            if (_necessaryFishAmountInScene > CurrentFishNumberInScene)
            {
                Instantiate(RandomFish, SpawnPoint, Quaternion.identity, GameObjectsFolder.Get(Folder.FBX));
            }
        }
    }
}
