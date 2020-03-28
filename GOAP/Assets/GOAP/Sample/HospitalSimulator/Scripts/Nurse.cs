namespace GOAP
{
    public class Nurse : Agent
    {
        public override void Start()
        {
            base.Start();

            var s1 = new SubGoal("treatPatient", 1, false);

            var priority = 3;
            Goals.Add(s1, priority);
        }
    }
}