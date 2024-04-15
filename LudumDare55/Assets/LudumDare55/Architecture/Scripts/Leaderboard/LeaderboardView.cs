using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare55
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private List<CreateScriptableObjectOfEmployee> allEmployees;
        [SerializeField] private Image[] leaderboardPortraits;
        [SerializeField] private Sprite playerPortrait;
        [SerializeField] private TextMeshProUGUI[] employeeScores;
        [SerializeField] private TextMeshProUGUI[] employeeNames;
        [SerializeField] private Image buttonImages;
        [SerializeField] private Transform buttonSpawnPoint;

        private CreateScriptableObjectOfEmployee createdEmployee;

        public void Start()
        {
            createdEmployee.employeeScore = PlayerPrefs.GetInt("PlayerScore");
            createdEmployee.employeeId = "You";
            createdEmployee.employeePortrait.sprite = playerPortrait;
            allEmployees.Add(createdEmployee);
            DisplayEmployees();
        }

        public void DisplayEmployees()
        {
            for (int i = 0; i < allEmployees.Count - 1; i++)
            {
                for (int j = 0; j < allEmployees.Count - i - 1; j++)
                {
                    if (allEmployees[i].employeeScore > allEmployees[j + 1].employeeScore)
                    {
                        (allEmployees[j], allEmployees[j + 1]) = (allEmployees[j + 1], allEmployees[j]);
                    }
                }
            }

            for (int i = 0; i < allEmployees.Count; i++)
            {
                leaderboardPortraits[i] = allEmployees[i].employeePortrait;
                employeeScores[i].text = allEmployees[i].employeeScore + "/" + PlayerPrefs.GetInt("RequiredAmount");
                employeeNames[i].text = allEmployees[i].employeeId;
            }

            if (createdEmployee.employeeScore > allEmployees[2].employeeScore)
            {
                
            }
        }
    }
}
