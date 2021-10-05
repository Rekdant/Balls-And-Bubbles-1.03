using Game.Events;

public class GreenSphere : Sphere 
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddGreenSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.GreenSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.GreenSphereVFX, transform.position);
    }
}