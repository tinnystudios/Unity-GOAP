using System.Linq;
using Games.Core;

namespace GOAP
{
    public class GetTreated : NavMeshAction
    {
        public StringReference IsCured;
        public StringReference Treated;

        public Cubicle Cubicle;

        public override bool PrePerform()
        {
            var cubicles = Inventory.GetListOfType<Cubicle>();

            if (cubicles.Count == 0)
                return false;

            Cubicle = cubicles[0];
            Inventory.Remove(Cubicle);

            Target = Cubicle.Destination.gameObject;

            return base.PrePerform();
        }

        public override bool PostPerform()
        {
            Target = null;

            World.Instance.GetWorldStates().ModifyState(Treated.Value, 1);
            States.ModifyState(IsCured.Value, 1);
            Inventory.Remove(Cubicle);
            return true;
        }
    }
}