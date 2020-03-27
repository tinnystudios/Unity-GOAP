namespace GOAP
{
    public sealed class World
    {
        private static WorldStates _worldStates = new WorldStates();
        public static World Instance { get; } = new World();

        public WorldStates GetWorldStates() => _worldStates;
    }
}