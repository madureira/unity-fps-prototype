using System;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float activeTimeInSeconds = 10;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    private bool _isRunning;
    private float _activeTime;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_activeTime < 0)
        {
            this.enabled = false;
            return;
        }

        if (_isRunning)
        {
            _navMesh.destination = player.transform.position;
            _activeTime -= Time.deltaTime;
            return;
        }

        _isRunning = true;
        _animator.Play("zombie_running");
    }

    private void OnEnable()
    {
        _activeTime = activeTimeInSeconds;
    }

    private void OnDisable()
    {
        _activeTime = 0;
        _isRunning = false;
        _animator.Play("zombie_idle");
        _navMesh.destination = this.transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.LogWarning("Killed by Zombie!!!");
        }
    }
}
