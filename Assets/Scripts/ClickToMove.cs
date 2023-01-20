using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
		{
		 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		 RaycastHit hit;
		 if(Physics.Raycast(ray, out hit))
		  {
		    agent.SetDestination(hit.point);
		  }
		} 
    }
}
