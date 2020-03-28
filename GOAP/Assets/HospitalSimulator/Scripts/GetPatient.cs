using Games.Core;
using UnityEngine;

namespace GOAP
{
    public class GetPatient : NavMeshAction
    {
        public IItem Cubicle;

        public override bool PrePerform()
        {
            if (CubicleManager.Inventory.Empty)
                return false;

            Target = PatientManager.Get();
            var agent = Target.GetComponent<Agent>();

            var top = CubicleManager.Inventory.Items[0];
            CubicleManager.Inventory.Transfer(top, agent.Inventory);
            Cubicle = top;

            World.Instance.GetWorldStates().ModifyState("FreeCubicle", -1);
            return base.PrePerform();
        }

        public override bool PostPerform()
        {
            World.Instance.GetWorldStates().ModifyState("hasPatient", -1);
            var agent = Target.GetComponent<Agent>();
            agent.Inventory.Add(Cubicle);

            return true;
        }
    }
}
