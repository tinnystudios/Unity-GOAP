using System;

namespace GOAP
{
    [Serializable]
    public class WorldState
    {
        public StringReference KeyReference;
        public string Key => KeyReference.Value;
        public int Value;
    }
}