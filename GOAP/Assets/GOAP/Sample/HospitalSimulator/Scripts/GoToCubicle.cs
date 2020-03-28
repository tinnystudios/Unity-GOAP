using Games.Core;

namespace GOAP
{
    public class GoToCubicle : NavMeshAction
    {
        public Cubicle Cubicle;

        public override bool PrePerform()
        {
            var cubicles = Inventory.GetListOfType<Cubicle>();
            if (cubicles.Count == 0)
                return false;

            Cubicle = cubicles[0];
            Target = Cubicle.gameObject;

            return base.PrePerform();
        }

        public override bool PostPerform()
        {
            Target = null;
            Inventory.Remove(Cubicle);

            World.Instance.GetWorldStates().ModifyState("treatingPatient", 1);

            // This is the nurse 'treating' the patient
            CubicleManager.Inventory.Add(Cubicle);
            World.Instance.GetWorldStates().ModifyState("freeCubicle", 1);

            return base.PostPerform();
        }
    }
}