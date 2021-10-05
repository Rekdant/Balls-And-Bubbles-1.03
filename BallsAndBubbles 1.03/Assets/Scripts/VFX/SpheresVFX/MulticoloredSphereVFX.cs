using System.Collections.Generic;
using UnityEngine;

public class MulticoloredSphereVFX : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spheres;
    [SerializeField] private int _spheresNumberToSpawn;
    [SerializeField] private float _spawnRadius;

    private GameObjectsFolder GameObjectsFolder
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private GameObject RandomSphere
    {
        get { return _spheres[Random.Range(0, _spheres.Count)]; }
    }
    private Vector2 RandomPointInSpawnRaius
    {
        get { return Random.insideUnitCircle * _spawnRadius; }
    }
    private Vector2 SpawnPoint
    {
        get { return new Vector2(transform.position.x + RandomPointInSpawnRaius.x, transform.position.y + RandomPointInSpawnRaius.y); }
    }

    private void OnValidate()
    {
        _spawnRadius = Mathf.Abs(_spawnRadius);
        _spheresNumberToSpawn = Mathf.Abs(_spheresNumberToSpawn);
    }

    private void Start()
    {
        SpawnRandomSpheres();       
    }

    private void SpawnRandomSpheres()
    {
        for (int i = 0; i < _spheresNumberToSpawn; i++)
        {
            Instantiate(RandomSphere, SpawnPoint, Quaternion.identity, GameObjectsFolder.Get(Folder.FBX));
        }

        Destroy(gameObject);
    }    
}