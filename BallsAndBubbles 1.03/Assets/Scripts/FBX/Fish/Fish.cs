using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fish : MonoBehaviour
{
    private const float Speed = 100;
    private const float MinIntervalRedefineMovementPoint = 1f;
    private const float MaxIntervalRedefineMovementPoint = 2f;

    private Rigidbody _rb;
    private Vector3 _movementPoint;

    protected AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }
    protected VFXPlayer VFXPlayer
    {
        get { return ServiceLocator.Resolve<VFXPlayer>(); }
    }
    private float MotionPointRedefineInterval
    {
        get { return Random.Range(MinIntervalRedefineMovementPoint, MaxIntervalRedefineMovementPoint); }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(RedefineMovementPoint());
    }

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Destroy()
    {
        AudioPlayer.PlaySound(Sounds.FishDestroy);
        VFXPlayer.Play(VFXType.WhiteSphereExplosion, transform.position);

        Destroy(gameObject);
    }

    protected virtual Vector3 DefineMovementPoint()
    {
        Sphere[] spheres = FindObjectsOfType<Sphere>();

        if (spheres.Length > 0)
        {
            Sphere sphere = spheres[Random.Range(0, spheres.Length)];
            return sphere.transform.position;
        }

        return Vector3.zero;
    }

    private IEnumerator RedefineMovementPoint()
    {
        while (true)
        {
            _movementPoint = DefineMovementPoint();
            yield return new WaitForSeconds(MotionPointRedefineInterval);
        }
    }

    private void Move()
    {
        if (_movementPoint != null)
        {
            _rb.velocity = (_movementPoint - transform.position) * Time.fixedDeltaTime * Speed;
            transform.LookAt(_movementPoint);
        }        
    }
}
