using UnityEngine;
using Game.Events;

public class YellowSphereVFX : SphereVFX
{
    private const float LifeTime = 1f;

    private void Start()
    {
        AudioPlayer.PlaySound(Sounds.YellowSphereVFX);
        Destroy(gameObject, LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyEnemy(other);
    }
}
