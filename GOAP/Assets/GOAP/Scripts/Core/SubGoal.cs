using System;
using System.Collections.Generic;

namespace GOAP
{
    [Serializable]
    public class SubGoal
    {
        public StringReference Name;
        public int Priority;
        public int Target;

        public Dictionary<string, int> SubGoals = new Dictionary<string, int>();
        public bool Once;

        public void Initialize()
        {
            SubGoals.Add(Name.Value, Target);
        }
    }
}