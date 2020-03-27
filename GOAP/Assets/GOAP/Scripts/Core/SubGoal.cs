using System.Collections.Generic;

namespace GOAP
{
    public class SubGoal
    {
        public Dictionary<string, int> SubGoals = new Dictionary<string, int>();
        public bool Once;

        public SubGoal(string s, int i, bool once)
        {
            SubGoals.Add(s, i);
            Once = once;
        }
    }
}