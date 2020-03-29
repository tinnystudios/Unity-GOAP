using Random = UnityEngine.Random;

namespace GOAP
{
    public class Nurse : Agent
    {
        public override void Start()
        {
            base.Start();
            Invoke("GetTired", Random.Range(5,20));
        }

        private void GetTired()
        {
            States.ModifyState("exhausted", 1);
            Invoke("GetTired", Random.Range(5, 20));
        }
    }
}