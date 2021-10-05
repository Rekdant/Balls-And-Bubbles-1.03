using Game.Events;

public class RedSphere : Sphere
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddRedSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.RedSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.RedSphereVFX, transform.position);
    }
}

