using UnityEngine;

public class SphereVFX : MonoBehaviour
{
    protected AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }
    protected VFXPlayer VFXPlayer
    {
        get { return ServiceLocator.Resolve<VFXPlayer>(); }
    }

    protected void DestroyEnemy(Collider collider)
    {
        if (collider.TryGetComponent(out Sphere sphere))
        {
            sphere.InitializeDestroy(0, true, false);
        }
        if (collider.TryGetComponent(out IFish fish))
        {
            fish.Destroy();
        }
    }
}
