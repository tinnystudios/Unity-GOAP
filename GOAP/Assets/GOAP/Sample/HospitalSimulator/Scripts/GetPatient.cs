﻿using Games.Core;
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

            var can = base.PrePerform();

            if(can)
                World.Instance.GetWorldStates().ModifyState("freeCubicle", -1);
            
            return can;
        }

        public override bool PostPerform()
        {
            World.Instance.GetWorldStates().ModifyState("hasPatient", -1);

            var targetAgent = Target.GetComponent<Agent>();

            var top = CubicleManager.Inventory.Items[0];
            CubicleManager.Inventory.Transfer(top, targetAgent.Inventory);
            Cubicle = top;

            Inventory.Add(Cubicle);

            return true;
        }
    }
}
