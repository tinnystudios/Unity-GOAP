using System;

namespace GOAP
{
    [Serializable]
    public class WorldState
    {
        public StringReference KeyReference;
        public int Value;

        public EOperator Operator;
        public string Key => KeyReference.Value;
    }

    public enum EOperator
    {
        Contains,
        Equals,
        LessThan,
        GreaterThan
    }
}