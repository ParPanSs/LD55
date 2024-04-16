using UnityEngine;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "New Employee", menuName = "Scriptable Object/Create Employee")]
    public class CreateScriptableObjectOfEmployee : ScriptableObject
    {
        public Sprite employeePortrait;
        public string employeeId;
        public int employeeScore;
    }
}