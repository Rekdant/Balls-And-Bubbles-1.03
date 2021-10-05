using Game.Events;

public class BlueSphere : Sphere 
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddBlueSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.BlueSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.BlueSphereVFX, transform.position);
    }
}

