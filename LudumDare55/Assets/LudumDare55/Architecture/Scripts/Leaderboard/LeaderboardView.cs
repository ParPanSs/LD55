using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare55
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private CreateScriptableObjectOfEmployee[] allEmployees;
        [SerializeField] private Image[] leaderboardPortraits;
        [SerializeField] private TextMeshProUGUI[] employeeScores;
        [SerializeField] private TextMeshProUGUI[] employeeNames;
        [SerializeField] private GameObject[] buttons;

        [SerializeField] private CreateScriptableObjectOfEmployee createdEmployee;

        public void Start()
        {
            createdEmployee.employeeScore = PlayerPrefs.GetInt("PlayerScore");
            DisplayEmployees();
        }

        public void DisplayEmployees()
        {
            for (int i = 0; i < allEmployees.Length - 1; i++)
            {
                for (int j = 0; j < allEmployees.Length - i - 1; j++)
                {
                    if (allEmployees[j].employeeScore < allEmployees[j + 1].employeeScore)
                    {
                        (allEmployees[j], allEmployees[j + 1]) = (allEmployees[j + 1], allEmployees[j]);
                    }
                }
            }
            var newEmployeeList = new List<CreateScriptableObjectOfEmployee>();

            for (int i = 0; i < allEmployees.Length; i++)
            {
                newEmployeeList.Add(allEmployees[i]);
                if (allEmployees[i].employeeScore <= createdEmployee.employeeScore)
                {
                    if (newEmployeeList.Contains(createdEmployee)) continue;
                    
                    newEmployeeList.Add(createdEmployee);
                    i++;
                    (newEmployeeList[i], newEmployeeList[i - 1]) = (newEmployeeList[i - 1], newEmployeeList[i]);
                    i--;
                }
            }
            
            if (!newEmployeeList.Contains(createdEmployee)) newEmployeeList.Add(createdEmployee);

            for (int i = 0; i < newEmployeeList.Count; i++)
            {
                leaderboardPortraits[i].sprite = newEmployeeList[i].employeePortrait;
                employeeScores[i].text = newEmployeeList[i].employeeScore + "/" + PlayerPrefs.GetInt("RequiredAmount");
                employeeNames[i].text = newEmployeeList[i].employeeId;
            }

            if (createdEmployee.employeeScore >= allEmployees[2].employeeScore)
            {
                buttons[0].SetActive(true);
            }
            else
            {
                buttons[1].SetActive(true);
            }
        }
    }
}
