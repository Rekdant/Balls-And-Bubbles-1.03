using System.Collections;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    private const int SpawnPositionZaxes = -5;

    [SerializeField] private GameObject _smoke;
    [SerializeField] private float _spawnInterval;

    private GameObjectsFolder GameObjectsFolder
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private Vector3 RandomPosition
    {
        get { return new Vector3(Random.Range(ValueHalper.RingMovementPointPositionXaxisMin, ValueHalper.RingMovementPointPositionXaxisMax),
            Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.RingMovementPointPositionYaxisMax), SpawnPositionZaxes); }
    }

    private void OnValidate()
    {
        _spawnInterval = Mathf.Abs(_spawnInterval);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            Instantiate(_smoke, RandomPosition, Quaternion.identity, GameObjectsFolder.Get(Folder.VFX));
        }      
    }
}
