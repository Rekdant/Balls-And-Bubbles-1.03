using UnityEngine;
using DG.Tweening;

public class GreenSphereVFX : SphereVFX
{
    private const float LifeTime = 3.1f;

    [SerializeField] private float _gravityForce;
    [SerializeField] private float _gravityRadius;

    private void OnValidate()
    {
        _gravityForce = Mathf.Abs(_gravityForce);
        _gravityRadius = Mathf.Abs(_gravityRadius);
    }

    private void Start()
    {
        PlayAnimation();
        Destroy(gameObject, LifeTime);
    }   

    private void FixedUpdate()
    {
        DetectSpheres();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyEnemy(other);
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.InsertCallback(0, PlaySound);
        sequence.Append(transform.DOScale(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), 1).From(new Vector3(0.1f, 0.1f, 0.1f), true, false));
        sequence.InsertCallback(1, PlaySound);
        sequence.Append(transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1).SetDelay(1));
        sequence.InsertCallback(2, PlaySound);
    }

    private void PlaySound()
    {
        AudioPlayer.PlaySound(Sounds.GreenSphereVFX);
    }

    private void DetectSpheres()
    {
        Collider[] detectedColliers = Physics.OverlapSphere(transform.position, _gravityRadius);
               
        foreach (var collider in detectedColliers)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                PullSphere(rigidbody);
            }            
        }
    }

    private void PullSphere(Rigidbody rigidbody)
    {
        rigidbody.AddForce(transform.position - rigidbody.transform.position * _gravityForce);
    }
}
