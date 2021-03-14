using UnityEngine;

public class Watcher : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 movementDirection;
    public Vector3 movementDistance;
    private bool _movingDown;
    private Zombie _zombie;
    private Vector3 _initialPosition;

    private void Start()
    {
        _zombie = enemy.GetComponent<Zombie>();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_movingDown)
        {
            transform.position += movementDirection;
        }
        else
        {
            transform.position -= movementDirection;
        }

        if (IsGreaterOrEqual(transform.position, (_initialPosition + movementDistance)))
        {
            _movingDown = false;
        }
        else if (IsLesserOrEqual(transform.position, _initialPosition))
        {
            _movingDown = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        _zombie.enabled = true;
    }

    private static bool IsGreaterOrEqual(Vector3 local, Vector3 other)
    {
        return (local.x >= other.x && local.z >= other.z);
    }

    private static bool IsLesserOrEqual(Vector3 local, Vector3 other)
    {
        return (local.x <= other.x && local.z <= other.z);
    }
}