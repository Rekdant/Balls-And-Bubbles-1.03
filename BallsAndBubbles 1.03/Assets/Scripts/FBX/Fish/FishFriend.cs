using UnityEngine;

public class FishFriend : Fish, IFish
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Sphere sphere))
        {
            sphere.InitializeDestroy(0, true, false);
        }
    }
}
