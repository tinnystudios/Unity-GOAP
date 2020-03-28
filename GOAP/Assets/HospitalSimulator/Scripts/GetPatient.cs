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

            World.Instance.GetWorldStates().ModifyState("FreeCubicle", -1);
            return base.PrePerform();
        }

        public override bool PostPerform()
        {
            World.Instance.GetWorldStates().ModifyState("hasPatient", -1);

            var targetAgent = Target.GetComponent<Agent>();

            var top = CubicleManager.Inventory.Items[0];
            CubicleManager.Inventory.Transfer(top, targetAgent.Inventory);
            Cubicle = top;

            return true;
        }
    }
}
