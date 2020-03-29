using UnityEngine;

namespace GOAP
{
    [CreateAssetMenu]
    public class StringReference : ScriptableObject
    {
        public string Value;

        public override string ToString()
        {
            return Value;
        }
    }
}