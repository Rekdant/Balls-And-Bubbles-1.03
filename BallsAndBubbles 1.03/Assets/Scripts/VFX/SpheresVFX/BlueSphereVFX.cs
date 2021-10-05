using System.Collections;
using UnityEngine;

public class BlueSphereVFX : SphereVFX
{
    [SerializeField] private int _shotsCount;
    [SerializeField] private float _shotInterval;

    private ParticleSystem _particle;

    private void OnValidate()
    {
        _shotsCount = Mathf.Abs(_shotsCount);
        _shotInterval = Mathf.Abs(_shotInterval);
    }

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(Fire());
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Collider collider))
        {
            DestroyEnemy(collider);
        }       
    }

    private IEnumerator Fire()
    {
        float lifeTimeAfterShots = 0.5f;

        while (_shotsCount > 0)
        {
            _shotsCount--;
            DefinePosition();
            PlayShotPartycle();
            PlaySound();
            yield return new WaitForSeconds(_shotInterval);
        }

        Destroy(gameObject, lifeTimeAfterShots);
    }

    private void DefinePosition()
    {
        transform.position = new Vector2(Random.Range(ValueHalper.PlaySpacePositionXaxisMin, ValueHalper.PlaySpacePositionXaxisMax), ValueHalper.PlaySpacePositionYaxisMax);
    }

    private void PlayShotPartycle()
    {
        _particle.Play();
    }

    private void PlaySound()
    {
        AudioPlayer.PlaySound(Sounds.BlueSphereVFX);
    }    
}
