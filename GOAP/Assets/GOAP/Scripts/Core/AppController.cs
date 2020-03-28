using UnityEngine;

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
    }
}