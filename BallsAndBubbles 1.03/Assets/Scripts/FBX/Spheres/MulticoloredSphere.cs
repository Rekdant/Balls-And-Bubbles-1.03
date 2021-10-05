using System.Collections;
using UnityEngine;
using DG.Tweening;
using Game.Events;

public class MulticoloredSphere : Sphere
{
    private const float ChangeColorTime = 0.1f;
    private const float ColorChangeInterval = 0.2f;

    private Color[] _colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow, Color.white, Color.black };
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;       
    }   

    private new void Start()
    {
        base.Start();
        StartCoroutine(RefreshColor());
    }

    protected override void AddCollorSphereScore()
    {
        EventAggregator.Post(this, new SphereAddMulticoloredSphereScoreEvent { });
    }

    protected override void InstantiateSphereExplosion()
    {
        VFXPlayer.Play(VFXType.MulticoloredSphereExplosion, transform.position);
    }

    protected override void InstantiateSphereVFX()
    {
        VFXPlayer.Play(VFXType.MulticoloredSphereVFX, transform.position);
    }

    private IEnumerator RefreshColor()
    {
        while (true)
        {
            _material.DOColor(_colors[Random.Range(0, _colors.Length)], ChangeColorTime);
            yield return new WaitForSeconds(ColorChangeInterval);
        }
    }
}