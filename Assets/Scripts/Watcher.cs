using UnityEngine;

public class Watcher : MonoBehaviour
{
    public GameObject enemy;
    public float activeTimeInSeconds = 5;
    private bool _movingDown;
    private float _activeTime;
    private Zombie _zombie;

    private void Start()
    {
        _zombie = enemy.GetComponent<Zombie>();
    }

    private void Update()
    {
        if (_movingDown == false)
        {
            transform.position -= new Vector3(0.1f, 0, 0.1f);
        }
        else
        {
            transform.position += new Vector3(0.1f, 0, 0.1f);
        }

        if (transform.position.z > 10)
        {
            _movingDown = false;
        }
        else if (transform.position.z < -10)
        {
            _movingDown = true;
        }

        _activeTime -= Time.deltaTime;

        if (_activeTime > 0)
        {
            return;
        }

        _zombie.enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        _zombie.enabled = true;
        _activeTime = activeTimeInSeconds;
    }
}
