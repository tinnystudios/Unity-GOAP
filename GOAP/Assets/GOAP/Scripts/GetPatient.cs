namespace GOAP
{
    public class GetPatient : NavMeshAction
    {
        public override bool PrePerform()
        {
            Target = PatientManager.Get();
            return base.PrePerform();
        }
    }
}