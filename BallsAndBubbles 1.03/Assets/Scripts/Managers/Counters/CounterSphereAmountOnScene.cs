using UnityEngine;
using Game.Events;
using System.Collections;

public class CounterSphereAmountOnScene : MonoBehaviour
{
    private int _sphereAmountOnScene = 0;
    private int _point = 1;

    private void Awake()
    {
        SubscribeToEvent();
    }

    private void OnDestroy()
    {
        UnSubscribeFromEvent();
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        PostData();
    }

    private void SubscribeToEvent()
    {
        EventAggregator.Subscribe<SphereSpawnEvent>(OnSphereAmontEnlargeHandler);
        EventAggregator.Subscribe<SphereDestroyEvent>(OnSphereAmountReduceHandler);
    }

    private void UnSubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<SphereSpawnEvent>(OnSphereAmontEnlargeHandler);
        EventAggregator.Unsubscribe<SphereDestroyEvent>(OnSphereAmountReduceHandler);
    }

    private void OnSphereAmontEnlargeHandler(object sender, SphereSpawnEvent _) => UpdateSphereAmont(_point);

    private void OnSphereAmountReduceHandler(object sender, SphereDestroyEvent _) => UpdateSphereAmont(-_point);

    private void UpdateSphereAmont(int value)
    {
        _sphereAmountOnScene += value;
        PostData();
    }

    private void PostData()
    {
        EventAggregator.Post(this, new TransferFilteredSphereAmauntEvent { Value = _sphereAmountOnScene });
    }
}
    
