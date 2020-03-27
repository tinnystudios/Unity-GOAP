using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    public class Agent : MonoBehaviour
    {
        public List<Action> Actions = new List<Action>();
        public Dictionary<SubGoal, int> Goals = new Dictionary<SubGoal, int>();

        // Planner
        public Action CurrentAction;
        public SubGoal CurrentGoal;

        private Queue<Action> _actionQueue;
        private Planner _planner;

        public virtual void Start()
        {
            Actions = GetComponentsInChildren<Action>().ToList();
        }

        private void LateUpdate()
        {
            if (CurrentAction != null && CurrentAction.Running)
            {
                CurrentAction.Run();
                return;
            }

            if (_planner == null || _actionQueue == null)
            {
                _planner = new Planner();

                var sortedGoals = Goals.OrderByDescending(entry => entry.Value);

                foreach (var goal in sortedGoals)
                {
                    _actionQueue = _planner.Plan(Actions, goal.Key.SubGoals, null);
                    if (_actionQueue == null) 
                        continue;

                    CurrentGoal = goal.Key;
                    break;
                }
            }

            if (_actionQueue != null && _actionQueue.Count == 0)
            {
                if (CurrentGoal.Once)
                    Goals.Remove(CurrentGoal);

                _planner = null;
            }

            if (_actionQueue != null && _actionQueue.Count > 0)
            {
                CurrentAction = _actionQueue.Dequeue();
                if (!CurrentAction.PrePerform())
                {
                    // Force a new plan!
                    _actionQueue = null;
                }
            }
        }
    }
}
