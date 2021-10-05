using System.Collections;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private float _minPeriodValue;
    [SerializeField] private float _maxPeriodValue;

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }
    private VFXPlayer VFXplayer
    {
        get { return ServiceLocator.Resolve<VFXPlayer>(); }
    }
    private float IntervalBetweenTeleportations
    {
        get { return Random.Range(_minPeriodValue, _maxPeriodValue); }
    }
    private float RandomXaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionXaxisMin, ValueHalper.PlaySpacePositionXaxisMax); }
    }
    private float RandomYaxisPosition
    {
        get { return Random.Range(ValueHalper.PlaySpacePositionYaxisMin, ValueHalper.PlaySpacePositionYaxisMax); }
    }

    private void OnValidate()
    {
        _minPeriodValue = Mathf.Abs(_minPeriodValue);
        _maxPeriodValue = Mathf.Clamp(_maxPeriodValue, _minPeriodValue, int.MaxValue);
    }

    private void Start()
    {
        StartCoroutine(ToTeleport());
    }

    private IEnumerator ToTeleport()
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervalBetweenTeleportations);

            transform.position = new Vector2(RandomXaxisPosition, RandomYaxisPosition);

            VFXplayer.Play(VFXType.Teleportation, transform.position);
            AudioPlayer.PlaySound(Sounds.Teleportation);
        }
    }
}
