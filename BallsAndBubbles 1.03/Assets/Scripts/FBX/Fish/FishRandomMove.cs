using System.Collections;
using UnityEngine;
using Game.Events;

public class FishRandomMove : Fish, IFish
{
    public override void Destroy()
    {
        EventAggregator.Post(this, new FishDestroyEvent { });
        VFXPlayer.Play(VFXType.PlusOne, transform.position);

        base.Destroy();
    }

    protected override Vector3 DefineMovementPoint()
    {       
        return new Vector2(Random.Range(ValueHalper.PlaySpacePositionXaxisMin, ValueHalper.PlaySpacePositionXaxisMax), 
            Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.RingMovementPointPositionYaxisMax));
    }
}
