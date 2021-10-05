using UnityEngine;
using Game.Events;

public class RedSphereVFX : SphereVFX
{
   private const float LifeTime = 1;

    private void Start()
    {
        AudioPlayer.PlaySound(Sounds.RedSphereVFX);
        Destroy(gameObject, LifeTime);       
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyEnemy(other);
    }
}
