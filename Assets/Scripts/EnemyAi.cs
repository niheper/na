using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController Player;
    
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    void Start()
    {

        InitComponentLinks();

        PickNewPatrolPoint();
       
    }

    void Update()
    {
        var direction = Player.transform.position - transform.position;

        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if(hit.collider.gameObject == Player.gameObject)
            {
                _isPlayerNoticed = true;
            }
            else
            {
                _isPlayerNoticed = false;
            }
        }
        else
        {
            _isPlayerNoticed = false;
        }

        PatrolUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
