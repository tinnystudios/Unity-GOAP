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
            var dist = Vector3.Distance(Agent.transform.position, Target.transform.position);
            if (dist >= 2 || Completing) 
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