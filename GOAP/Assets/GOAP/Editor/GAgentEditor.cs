using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using GOAP;

[CustomEditor(typeof(GAgentVisual))]
[CanEditMultipleObjects]
public class GAgentVisualEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();
        GAgentVisual agent = (GAgentVisual) target;
        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<Agent>().CurrentAction);
        GUILayout.Label("Actions: ");
        foreach (Action a in agent.gameObject.GetComponent<Agent>().Actions)
        {
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.PreconditionsMap)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.AfterEffectsMap)
                eff += e.Key + ", ";

            GUILayout.Label("====  " + a.Name + "(" + pre + ")(" + eff + ")");
        }
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<Agent>().Goals)
        {
            GUILayout.Label("---: ");
            foreach (KeyValuePair<string, int> sg in g.Key.SubGoals)
                GUILayout.Label("=====  " + sg.Key);
        }
        serializedObject.ApplyModifiedProperties();
    }
}