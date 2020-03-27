using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace GOAP
{
    public class Node
    {
        public Node Parent;
        public float Cost;
        public Dictionary<string, int> State;
        public Action Action;

        public Node(Node parent, float cost, Dictionary<string, int> allStates, Action action)
        {
            Parent = parent;
            Cost = cost;
            State = new Dictionary<string, int>(allStates);
            Action = action;
        }

        public Node(Node parent, float cost, Dictionary<string, int> allStates, Dictionary<string, int> states, Action action)
        {
            Parent = parent;
            Cost = cost;
            State = new Dictionary<string, int>(allStates);

            foreach (var state in states.Where(state => !State.ContainsKey(state.Key)))
            {
                State.Add(state.Key, state.Value);
            }

            Action = action;
        }
    }
}