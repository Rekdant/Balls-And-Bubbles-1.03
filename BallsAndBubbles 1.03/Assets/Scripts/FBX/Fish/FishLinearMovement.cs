using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FishLinearMovement : MonoBehaviour, IFish
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;
    private Vector3 _direction;

    private AudioPlayer AudioPlayer
    {
        get { return ServiceLocator.Resolve<AudioPlayer>(); }
    }
    private VFXPlayer VFXplayer
    {
        get { return ServiceLocator.Resolve<VFXPlayer>(); }
    }

    private void OnValidate()
    {
        _speed = Mathf.Abs(_speed);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        DefineDirection();
        DefineTurn();
    }

    private void FixedUpdate()
    {
        Move();      
    }

    public void Destroy()
    {
        AudioPlayer.PlaySound(Sounds.FishDestroy);

        VFXplayer.Play(VFXType.PlusOne, transform.position);
        VFXplayer.Play(VFXType.WhiteSphereExplosion, transform.position);

        Destroy(gameObject);
    }

    private void DefineDirection()
    {
        _direction = new Vector3(0, transform.position.y, 0) - transform.position;
    }

    private void DefineTurn()
    {
        _rb.rotation = Quaternion.LookRotation(_direction);
    }

    private void Move()
    {        
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
    }   
}
