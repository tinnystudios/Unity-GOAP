﻿using System.Linq;
using Games.Core;

namespace GOAP
{
    public class GetTreated : NavMeshAction
    {
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

            World.Instance.GetWorldStates().ModifyState("Treated", 1);
            States.ModifyState("isCured", 1);
            Inventory.Remove(Cubicle);
            return true;
        }
    }
}