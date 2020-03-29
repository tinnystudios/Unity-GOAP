namespace GOAP
{
    public class TakeABreak : NavMeshAction
    {
        public override bool PostPerform()
        {
            States.RemoveState("exhausted");
            return true;
        }
    }
}