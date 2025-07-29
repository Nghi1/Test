using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform nv; 
    private NavMeshAgent agent;
    public HealthHp healthHp; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (healthHp != null)
        {
            healthHp.SetMaxHealth(100);
        }
    }

    void Update()
    {
        if (nv != null && agent.isOnNavMesh)
        {
            agent.SetDestination(nv.position);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            healthHp.TakeDamage(10);
        }
    }
}
