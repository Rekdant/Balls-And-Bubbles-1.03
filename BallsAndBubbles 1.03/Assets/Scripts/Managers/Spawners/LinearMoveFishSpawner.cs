using System.Collections;
using UnityEngine;

enum Side
{
    Left,
    Right
}

public class LinearMoveFishSpawner : MonoBehaviour
{
    [SerializeField] private float _minFishSpawnInterval;
    [SerializeField] private float _maxFishSpawnInterval;
    [SerializeField] private float _distanceFromPlayCenter;
    [SerializeField] private Side _side;
    [SerializeField] private FishLinearMovement[] _fishes;    

    private GameObjectsFolder GameObjectsFolder
    { 
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private float RandomFishSpawnInterval
    {
        get { return Random.Range(_minFishSpawnInterval, _maxFishSpawnInterval); }
    }
    private FishLinearMovement RandomFish
    {
        get { return _fishes[Random.Range(0, _fishes.Length)]; }
    }
    private float RandomPlaySpacePositionYaxis
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.PlaySpacePositionYaxisMax); } 
    }

    private void OnValidate()
    {
        _distanceFromPlayCenter = Mathf.Abs(_distanceFromPlayCenter);
        _minFishSpawnInterval = Mathf.Abs(_minFishSpawnInterval);
        _maxFishSpawnInterval = Mathf.Clamp(_maxFishSpawnInterval, _minFishSpawnInterval, int.MaxValue);
    }

    private void Start()
    {      
        StartCoroutine(CreateFish());
    }

    private IEnumerator CreateFish()
    {
        if (_side == Side.Left)
        {
            _distanceFromPlayCenter *= -1;
        }

        while (true)
        {          
            yield return new WaitForSeconds(RandomFishSpawnInterval);
            Instantiate(RandomFish, new Vector2(_distanceFromPlayCenter, RandomPlaySpacePositionYaxis), Quaternion.identity, GameObjectsFolder.Get(Folder.FBX));
        }        
    }
}
