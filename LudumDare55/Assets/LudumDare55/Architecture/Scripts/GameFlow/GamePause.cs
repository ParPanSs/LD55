using System;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare55
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private GameObject pausePanel;
        
        private bool _isGamePaused;
        
        private void Start()
        {
            pauseButton.onClick.AddListener(SetPause);
        }

        private void SetPause()
        {
            _isGamePaused = !_isGamePaused;
            Time.timeScale = _isGamePaused ? 0 : 1;
            pausePanel.SetActive(_isGamePaused);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) SetPause();
        }

        private void OnDestroy()
        {
            pauseButton.onClick.RemoveListener(SetPause);
        }
    }
}