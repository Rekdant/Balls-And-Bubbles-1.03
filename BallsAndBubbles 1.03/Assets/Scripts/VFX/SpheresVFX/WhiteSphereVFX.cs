using UnityEngine;

public class WhiteSphereVFX : SphereVFX
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _speed;

    private Sphere _target;

    private void OnValidate()
    {
        _lifeTime = Mathf.Abs(_lifeTime);
        _speed = Mathf.Abs(_speed);
    }

    private void Start()
    {
        AudioPlayer.PlaySound(Sounds.WhiteSphereVFX);
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyEnemy(other);
    }

    private void Move()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            SetTerget();
        }
    }

    private void SetTerget()
    {
        Sphere[] spheres = FindObjectsOfType<Sphere>();

        if (spheres.Length > 0)
        {
            _target = spheres[Random.Range(0, spheres.Length)];
        }
    }
}
