using GOAP;
using UnityEngine;

[ExecuteInEditMode]
public class GAgentVisual : MonoBehaviour
{
    public Agent Agent;

    private void Start()
    {
        Agent = this.GetComponent<Agent>();
    }
}
