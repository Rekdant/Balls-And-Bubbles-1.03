using UnityEngine;

public class FishMovementAround : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private int _speed;

    private void Update()
    {
        EstablishPosition();
        Rotate();
    }

    private void EstablishPosition()
    {
        transform.position = _center.position;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }
}
