using System.Collections.Generic;
using System.Linq;
using Debug = UnityEngine.Debug;

namespace GOAP
{
    public class Planner
    {
        public Queue<Action> Plan(List<Action> actions, Dictionary<string, int> goal, WorldStates states)
        {
            var usableActions = new List<Action>();
            foreach (var action in actions)
            {
                if(action.IsAchievable())
                    usableActions.Add(action);
            }

            var leaves = new List<Node>();
            var start = new Node(null, 0, World.Instance.GetWorldStates().GetStates(), null);

            var success = BuildGraph(start, leaves, usableActions, goal);

            if (!success)
            {
                Debug.Log("No plan found");
                return null;
            }

            Node cheapest = null;
            foreach (var leaf in leaves)
            {
                if (cheapest == null)
                    cheapest = leaf;
                else if (leaf.Cost < cheapest.Cost)
                {
                    cheapest = leaf;
                }
            }

            var result = new List<Action>();
            var n = cheapest;

            while (n != null)
            {
                if (n.Action != null)
                    result.Insert(0, n.Action);

                n = n.Parent;
            }

            var queue = new Queue<Action>();
            foreach (var action in result)
                queue.Enqueue(action);

            Debug.Log("The plan is:");
            foreach (var action in queue)
            {
                Debug.Log($"{action.Name}");
            }

            return queue;
        }

        private bool BuildGraph(Node parent, List<Node> leaves, List<Action> usableActions, Dictionary<string, int> goal)
        {
            var foundPath = false;
            foreach (var action in usableActions)
            {
                if (action.IsAchievableGiven(parent.State))
                {
                    var currentState = new Dictionary<string, int>(parent.State);
                    foreach (var effect in action.AfterEffects)
                    {
                        if (!currentState.ContainsKey(effect.Key))
                            currentState.Add(effect.Key, effect.Value);
                    }

                    var node = new Node(parent, parent.Cost + action.Cost, currentState, action);
                    if (GoalAchieved(goal, currentState))
                    {
                        leaves.Add(node);
                        foundPath = true;
                    }
                    else
                    {
                        // Avoid endless plans
                        var subset = ActionSubset(usableActions, action);
                        foundPath = BuildGraph(node, leaves, subset, goal);
                    }
                }
            }

            return foundPath;
        }

        private List<Action> ActionSubset(List<Action> actions, Action removeMe)
        {
            var subset = new List<Action>();
            foreach (var action in actions)
            {
                if(!action.Equals(removeMe))
                    subset.Add(action);
            }

            return subset;
        }

        private bool GoalAchieved(Dictionary<string, int> goals, Dictionary<string, int> state)
        {
            foreach (var goal in goals)
            {
                if (!state.ContainsKey(goal.Key))
                    return false;
            }

            return true;
        }
    }
}