using System;
using UnityEngine;
using UnityEngine.AI;

namespace SmellSystem
{
    public class ScentFollow : MonoBehaviour
    {
        [Header("NavMesh")]
        [SerializeField] private NavMeshAgent Agent;
        [SerializeField] private Transform Target;
        
        [SerializeField] private TrailRenderer trail;

        private Vector3 startPos;
        private bool trailActive;
        private float timer;

        private void Start()
        {
            startPos = transform.position;
            trailActive = false;
            timer = 0;
            
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!trailActive) return;

            if (timer >= trail.time + Agent.speed)
            {
                trailActive = false;
                transform.position = startPos;
                timer = 0;
                
                gameObject.SetActive(false);
            }

            else
                timer += Time.deltaTime;
        }

        public void ActivateTrail()
        {
            trailActive = true;
            Agent.SetDestination(Target.position);
        }
    }
}
