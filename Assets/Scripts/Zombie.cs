using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMesh.destination = player.transform.position;
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.LogWarning("Peguei!!!!");
        }
    }
}
