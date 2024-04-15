using UnityEngine;
using UnityEngine.UI;

namespace LudumDare55
{
    [CreateAssetMenu(fileName = "New Employee", menuName = "Scriptable Object/Create Employee")]
    public class CreateScriptableObjectOfEmployee : ScriptableObject
    {
        public Image employeePortrait;
        public string employeeId;
        public int employeeScore;
    }
}