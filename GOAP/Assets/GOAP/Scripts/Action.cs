using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;

namespace GOAP
{
    using UnityEngine;

    // TODO Decouple NavMeshAgent from Action
    public abstract class Action : MonoBehaviour
    {
        public string Name = "Action";

        public GameObject Target;
        public NavMeshAgent Agent;

        [Tooltip("How much does the agent dislike doing this action?")]
        public float Cost = 1.0f;
        public float Duration = 0;

        public WorldState[] PreConditions;
        public WorldState[] AfterEffects;

        private Dictionary<string, int> _preconditions = new Dictionary<string, int>();
        private Dictionary<string, int> _afterEffects = new Dictionary<string, int>();

        public bool Running { get; set; }

        private void Awake()
        {
            foreach (var condition in PreConditions)
                _preconditions.Add(condition.Key, condition.Value);

            foreach (var condition in AfterEffects)
                _afterEffects.Add(condition.Key, condition.Value);
        }

        public bool IsAchievable() => true;

        public bool IsAchievableGiven(Dictionary<string, int> preConditions)
        {
            return _preconditions.All(preCondition => preConditions.ContainsKey(preCondition.Key));
        }

        public abstract bool PrePerform();
        public abstract bool PostPerform();
    }
}

