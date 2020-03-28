namespace GOAP
{
    public class Patient : Agent
    {
        public override void Start()
        {
            base.Start();

            var waitingGoal = new SubGoal("isWaiting", 1, true);
            var treatGoal = new SubGoal("isTreated", 1, true);
            var goHomeGoal = new SubGoal("isHome", 1, true);

            Goals.Add(waitingGoal, 3);
            Goals.Add(treatGoal, 5);
            Goals.Add(goHomeGoal, 3);
        }
    }
}