using Game.Events;

public class BlackSphere : Sphere 
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddBlackSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.BlackSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.BlackSphereVFX, transform.position);
    }
}

