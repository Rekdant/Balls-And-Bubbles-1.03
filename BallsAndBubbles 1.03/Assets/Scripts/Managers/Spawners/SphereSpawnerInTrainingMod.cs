using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereSpawnerInTrainingMod : MonoBehaviour
{
    [SerializeField] private List<Sphere> _spheres = new List<Sphere>();
    [SerializeField] private Button _startButton;

    private GameObjectsFolder GameObjectsFolder
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private float RandomXaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionXaxisMin, ValueHalper.PlaySpacePositionXaxisMax); }
    }
    private float RandomYaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.PlaySpacePositionYaxisMax); }
    }
    private Sphere RandomSphere
    {
        get { return _spheres[Random.Range(0, _spheres.Count)]; }
    }

    private void Awake()
    {
        _startButton.onClick.AddListener(StartSpawn);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartSpawn);
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void SetSphere(Sphere sphere)
    {
        if (_spheres.Contains(sphere))
        {
            if (_spheres.Count > 0)
            {
                _spheres.Remove(sphere);
            }
        }
        else
        {
            _spheres.Add(sphere);
        }
    }

    private void StartSpawn()
    {
        if (_spheres.Count > 0)
        {
            CreateStartingSpheres();
            StartCoroutine(SpawnSphere());
        }

        Time.timeScale = 1;
    }

    private void CreateStartingSpheres()
    {
        int startingSpheresNumber = 10;

        for (int i = 0; i < startingSpheresNumber; i++)
        {
            InstantiateSphere(RandomYaxisPosition);
        }
    }

    private IEnumerator SpawnSphere()
    {
        float sphereCreationInterval;

        if (PlayerPrefs.HasKey(ValueHalper.KeyIntensitySphereSpawnInTrainingMod))
        {
            sphereCreationInterval = PlayerPrefs.GetFloat(ValueHalper.KeyIntensitySphereSpawnInTrainingMod);
        }
        else
        {
            sphereCreationInterval = ValueHalper.DefaultIntensitySphereSpawnInTrainingMod;
        }

        while (true)
        {
            yield return new WaitForSeconds(sphereCreationInterval);
            InstantiateSphere(ValueHalper.PlaySpacePositionYaxisMax);
        }
    }

    private void InstantiateSphere(float yAxis)
    {
        Instantiate(RandomSphere, new Vector2(RandomXaxisPosition, yAxis), transform.rotation, GameObjectsFolder.Get(Folder.FBX).transform);
    }
}
