using Game.Events;

public class WhiteSphere : Sphere
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddWhiteSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.WhiteSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.WhiteSphereVFX, transform.position);
    }
}
