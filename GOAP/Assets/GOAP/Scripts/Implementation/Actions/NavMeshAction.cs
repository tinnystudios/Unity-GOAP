using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public class NavMeshAction : Action
    {
        public NavMeshAgent Agent;

        public void OnValidate()
        {
            Agent = Agent ?? GetComponentInParent<NavMeshAgent>();
        }

        public override bool PrePerform()
        {
            if (Target != null)
            {
                Running = true;
                Agent.SetDestination(Target.transform.position);
                return true;
            }
            else
                return false;
        }

        public override bool PostPerform()
        {
            return true;
        }

        public override void Run()
        {
            if (!Agent.hasPath || !(Agent.remainingDistance < 1f) || Completing) 
                return;

            StartCoroutine(Routine());
            Completing = true;

            IEnumerator Routine()
            {
                yield return new WaitForSeconds(Duration);
                Complete();
            }
        }
    }
}