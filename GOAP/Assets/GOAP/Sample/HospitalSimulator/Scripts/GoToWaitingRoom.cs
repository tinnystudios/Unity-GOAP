namespace GOAP
{
    public class GoToWaitingRoom : NavMeshAction
    {
        public override bool PostPerform()
        {
            World.Instance.GetWorldStates().ModifyState("hasPatient", 1);
            PatientManager.Add(Agent.gameObject);

            States.ModifyState("atHospital", 1);

            return base.PostPerform();
        }
    }
}