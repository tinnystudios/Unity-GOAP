﻿using UnityEngine;

namespace GOAP
{
    public class AppController : MonoBehaviour
    {
        private void Start()
        {
            var cubicles = FindObjectsOfType<Cubicle>();
            foreach (var cubicle in cubicles)
            {
                CubicleManager.Inventory.Add(cubicle);
                World.Instance.GetWorldStates().ModifyState("freeCubicle", 1);
            }
        }

        void OnGUI()
        {
            GUILayout.BeginVertical("Box");
            {
                GUILayout.Label("World States");
                var states = World.Instance.GetWorldStates().GetStates();
                foreach (var state in states)
                {
                    GUILayout.Label($"{state.Key}: {state.Value}");
                }
            }
        }
    }
}