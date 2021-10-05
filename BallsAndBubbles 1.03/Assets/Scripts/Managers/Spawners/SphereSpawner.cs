using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private int _starterSpheresNumber;
    [SerializeField] private float _sphereCreationInterval;
    [SerializeField] private List<Sphere> _spheres;

    private GameObjectsFolder GameObjectsFolder
    {
        get { return ServiceLocator.Resolve<GameObjectsFolder>(); }
    }
    private Sphere RandomSphere
    {
        get { return _spheres[Random.Range(0, _spheres.Count)]; }
    }
    private float RandomXaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionXaxisMin, ValueHalper.PlaySpacePositionXaxisMax); }
    }
    private float RandomYaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.RingMovementPointPositionYaxisMax); }
    }

    private void OnValidate()
    {
        _starterSpheresNumber = Mathf.Abs(_starterSpheresNumber);
        _sphereCreationInterval = Mathf.Abs(_sphereCreationInterval);
    }

    private void Start()
    {
        CreateStarterSpheres();
        StartCoroutine(SpawnSphere());        
    }   

    private void CreateStarterSpheres()
    {
        for (int i = 0; i < _starterSpheresNumber; i++)
        {
            InstantiateSphere(RandomYaxisPosition);
        }
    }

    private IEnumerator SpawnSphere()
    {
        while (true)
        {
            yield return new WaitForSeconds(_sphereCreationInterval);
            InstantiateSphere(ValueHalper.PlaySpacePositionYaxisMax);
        }
    }

    private void InstantiateSphere(float yAxis)
    {
        Instantiate(RandomSphere, new Vector2(RandomXaxisPosition, yAxis), transform.rotation, GameObjectsFolder.Get(Folder.FBX).transform);
    }
}
