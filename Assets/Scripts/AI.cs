using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//importante añadir esto

public class AI : MonoBehaviour
{
    enum State
    {
        Patrolling,
        Chasing,
        Attacking,
    }

    State currentState;
    NavMeshAgent agent;

    public Transform[] destinationPoints;
    int destinationIndex = 0; 

    public Transform player;
    [SerializeField]
    float visionRange; 
    float attackRange;

    void Awake ()//examen
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start() //examen
    {
        currentState = State.Patrolling; 

        destinationIndex = Random.Range(0, destinationPoints.Length);
    }

    void Update() //examen
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();
            break;

            case State.Chasing:
                Chase();
            break;

            case State.Attacking:
                Attack();
            break;
        }
    }


     
    /*void Travel ()
    {
        if(agent.remainingDistance <= 0.2)
        {
            currentState = State.Patrolling;
        }

        if(Vector.Distance(transform.position, player.position) < visionRange)
    }*/



    void Patrol() //examen
    {
        agent.destination = destinationPoints[destinationIndex].position;

        if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 1f)
        {
            destinationIndex = Random.Range(0, destinationPoints.Length);
        }

        if(DistanceToTarget(visionRange))
        {
            currentState = State.Chasing;
        }

        
        /*
        if(Vector3.Distance(transform.position, player.position) < visionRange)
        {
            currentState = State.Chasing; 
        }
         
        if(RandomPoint(transform.position, patrolRange, out randomPosition))
        {
            agent.destination = randomPosition;
        }

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
        */


    }

    bool DistanceToTarget(float distance)//examen
    {
        if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < distance)
        {
            return true;
        }
        return false;
    }
    
    void Chase() //examen
    {
        agent.destination = player.position; 

        if(DistanceToTarget(visionRange) == false)
        {
            currentState = State.Patrolling; 
        }

        if(DistanceToTarget(attackRange))
        {
            currentState = State.Attacking;
        }
    }

    void Attack () //examen
    {
        Debug.Log("Ataque");

        if (!DistanceToTarget(attackRange))
        {
            currentState = State.Chasing;
        }
    }

    /*bool AttackRange ()//examen
    {
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            return true;
        }

        return false;
    }*/

    void OnDrawGizmos()//examen
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
