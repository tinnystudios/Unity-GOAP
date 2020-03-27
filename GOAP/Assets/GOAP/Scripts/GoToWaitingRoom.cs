namespace GOAP
{
    public class GoToWaitingRoom : NavMeshAction
    {
        public override bool PostPerform()
        {
            World.Instance.GetWorldStates().ModifyState("hasPatient", 1);
            PatientManager.Add(Agent.gameObject);

            return base.PostPerform();
        }
    }
}