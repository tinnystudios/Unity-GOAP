using System.Collections.Generic;

namespace GOAP
{
    public class WorldStates
    {
        private readonly Dictionary<string, int> _states = new Dictionary<string, int>();

        public bool HasState(string key) => _states.ContainsKey(key);

        public void AddState(string key, int value)
        {
            _states.Add(key, value);
        }

        public void RemoveState(string key)
        {
            _states.Remove(key);
        }

        public void ModifyState(string key, int value)
        {
            if (_states.ContainsKey(key))
            {
                _states[key] += value;
                if (_states[key] <= 0)
                    RemoveState(key);
            }
            else
                AddState(key, value);
        }

        public void SetState(string key, int value)
        {
            if (_states.ContainsKey(key))
                _states[key] = value;
            else
                _states.Add(key, value);
        }

        public Dictionary<string, int> GetStates() => _states;
    }
}