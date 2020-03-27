namespace GOAP
{
    public class Patient : Agent
    {
        public override void Start()
        {
            base.Start();

            var s1 = new SubGoal("isWaiting", 1, true);
            var priority = 3;
            Goals.Add(s1, priority);
        }
    }
}