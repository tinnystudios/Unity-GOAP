namespace GOAP
{
    public sealed class World
    {
        private static WorldStates _worldStates;
        private static readonly World instance = new World();

        public WorldStates GetWorldStates() => _worldStates;

        static World()
        {
            _worldStates = new WorldStates();
        }

        private World()
        {
        }

        public static World Instance
        {
            get { return instance; }
        }

        public WorldStates GetWorld()
        {
            return _worldStates;
        }
    }
}