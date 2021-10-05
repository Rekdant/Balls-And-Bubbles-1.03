using System.Collections;
using Game.Events;
using UnityEngine;

public class Ring : MonoBehaviour
{  
    private const float MovementSpeed = 2f;
    private const float RatationSpeed = 20;
    private const float MovementPointRedefineInterval = 3;

    private Vector2 _movementPoint;
    private MeshRenderer _meshRenarer;
    private ParticleSystem _particle;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartCoroutine(DefineMovementPoint());
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Sphere sphere))
        {           
            Color color = sphere.GetComponent<MeshRenderer>().material.color;           

            DestroySphere(sphere, color);
            SetColor(color);
            PlayParticle(color);

            EventAggregator.Post(this, new BorderColorChangeEvent { Color = color });
        }
    }

    private void Init()
    {
        _meshRenarer = GetComponent<MeshRenderer>();
        _particle = GetComponent<ParticleSystem>();
    }

    private IEnumerator DefineMovementPoint()
    {
        while (true)
        {
            _movementPoint = new Vector2(Random.Range(ValueHalper.RingMovementPointPositionXaxisMin, ValueHalper.RingMovementPointPositionXaxisMax), 
                Random.Range(ValueHalper.RingMovementPointPositionYaxisMin, ValueHalper.RingMovementPointPositionYaxisMax));

            yield return new WaitForSeconds(MovementPointRedefineInterval);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movementPoint, Time.deltaTime * MovementSpeed);
    }

    private void Rotate()
    {
        var detectObjects = Physics.OverlapSphere(transform.position, 3);

        if (detectObjects != null)
        {
            foreach (var item in detectObjects)
            {
                if (item.TryGetComponent(out ISphere _))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    return;
                }
                else
                {
                    transform.Rotate(Vector3.right * RatationSpeed * Time.deltaTime);
                }
            }
        }       
    }

    private void SetColor(Color color)
    {
        _meshRenarer.material.color = color;
    }

    private void PlayParticle(Color color)
    {
        _particle.startColor = color;
        _particle.Play();
    }   

    private void DestroySphere(Sphere sphere, Color color)
    {
        if (_meshRenarer.material.color == color)
        {
            sphere.InitializeDestroy(1, true, true);           
        }
        else
        {
            sphere.InitializeDestroy(1, true, false);
        }
    }   
}
