using Boo.Lang;
using UnityEngine;

namespace GOAP
{
    public static class PatientManager
    {
        public static List<GameObject> Patients = new List<GameObject>();

        public static void Add(GameObject go)
        {
            Patients.Add(go);
        }

        public static GameObject Get()
        {
            if (Patients.Count == 0)
                return null;

            var patient = Patients[0];
            if(Patients.Count > 0)
                Patients.Remove(Patients[0]);

            return patient;
        }
    }
}