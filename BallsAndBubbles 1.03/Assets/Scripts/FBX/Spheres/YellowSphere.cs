using UnityEngine;
using Game.Events;

public class YellowSphere : Sphere 
{
    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddYellowSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.YellowSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.YellowSphereVFX, new Vector2(transform.position.x, ValueHalper.PlaySpacePositionYaxisMin));
    }
}

