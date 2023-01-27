using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    enum State
    {
        Patrolling,
        Chasing
    }

    State currentState;
    NavMeshAgent agent;

    public Transform[] destinationPoints;
    int destinationIndex = 0; 

    public Transform player;
    [SerializeField]
    float visionRange; 

    void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentState = State.Patrolling; 

        destinationIndex = Random.Range(0, destinationPoints.Length);
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();
            break;
            case State.Chasing:
                Chase();
            break;
            default:
                Chase();
            break;
        }
    }
     
    void Travle ()
    {
        if(agent.remainingDistance <= 0.2)
        {
            currentState = State.Patrolling;
        }

        if8Vector.Distance((transform.position, player.position) < visionRange)
    }

    void Patrol()
    {
        agent.destination = destinationPoints[destinationIndex].position;

        /*if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 1)
        {
            destinationIndex = Random.Range(0, destinationPoints.Length);
        }*/
         
        if(RandomPoint(transform.position, patrolRange, out randomPosition))
        {
            agent.destination = randomPosition;
        }

        if(Vector3.Distance(transform.position, player.position) < visionRange)
        {
            currentState = State.Chasing; 
        
        bool RandomPoint (Vector3 cemter, float range, out Vector3 private void OnParticleCollision) 
        {
            Vector3 randompoint = center + Random.insideUnitSohere + range;
            NavMeshhit hit; 
            if(NavMesh.SamplePosition(randomPoint, out hit,, 4, NavMesh.AllAreas))
            {
                point = hit.positionreturn true;
            }
            point = Vector3.Zero;
            return false;
        }

        currentState = State.Traveling;
    }

    
    void Chase()
    {
        agent.destination = player.position; 

        if(Vector3.Distance(transform.position, player.position) > visionRange)
        {
            currentState = State.Patrolling; 
        }
    }

     void OnDrawGizmos()
    {
        foreach (Transform point in destinationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
