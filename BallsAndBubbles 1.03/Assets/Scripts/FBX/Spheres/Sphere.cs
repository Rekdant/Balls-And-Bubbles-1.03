using System.Collections;
using UnityEngine;
using Game.Events;

public abstract class Sphere : MonoBehaviour, ISphere
{
    protected MissionConditions Task
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }
    protected AudioPlayer AudioPlayer
    { 
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }
    protected VFXPlayer VFXPlayer
    {
        get { return ServiceLocator.Resolve<VFXPlayer>(); }
    }

    protected void Start()
    {
        EventAggregator.Post(this, new SphereSpawnEvent { });
    }

    private void OnDestroy()
    {
        EventAggregator.Post(this, new SphereDestroyEvent { });
    }

    public void InitializeDestroy(float delay, bool isAddCount, bool isUseSpell, bool isUseParticleSphereExplosion = true)
    {
        enabled = false;

        if (this is MulticoloredSphere)
        {
            isUseSpell = true;
        }

        StartCoroutine(Destroy(delay, isAddCount, isUseSpell, isUseParticleSphereExplosion = true));
    }

    protected abstract void AddCollorSphereScore();

    protected abstract void InstantiateSphereVFX();

    protected abstract void InstantiateSphereExplosion();

    private IEnumerator Destroy(float delay, bool isAddCount, bool isUseSpell, bool isUseParticleSphereExplosion = true)
    {
        yield return new WaitForSeconds(delay);

        if (isAddCount)
        {
            VFXPlayer.Play(VFXType.PlusOne, transform.position);
            AddCollorSphereScore();
        }
        if (isUseSpell)
        {
            InstantiateSphereVFX();
            EventAggregator.Post(this, new CameraShakeEvent { });
        }
        if (isUseParticleSphereExplosion)
        {
            InstantiateSphereExplosion();
        }
        
        AudioPlayer.PlaySound(Sounds.BubbleExplosion);       

        Destroy(gameObject);
    }   
}
