using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScentFollow : MonoBehaviour
{
    private NavMeshAgent Agent;

    public Transform Target;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        Agent.SetDestination(Target.position);
    }
}
