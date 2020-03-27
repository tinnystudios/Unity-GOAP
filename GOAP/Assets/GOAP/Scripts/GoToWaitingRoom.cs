namespace GOAP
{
    public class GoToWaitingRoom : Action
    {
        public override bool PrePerform()
        {
            return true;
        }

        public override bool PostPerform()
        {
            return true;
        }
    }
}