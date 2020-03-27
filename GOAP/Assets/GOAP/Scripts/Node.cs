using System.Collections.Generic;

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
    }
}