using System;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    private bool _isRunning;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _navMesh.destination = player.transform.position;

        if (_isRunning)
        {
            return;
        }

        _isRunning = true;
        _animator.Play("zombie_running");
    }

    private void OnDisable()
    {
        _isRunning = false;
        _animator.Play("zombie_idle");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.LogWarning("Peguei!!!!");
        }
    }
}
