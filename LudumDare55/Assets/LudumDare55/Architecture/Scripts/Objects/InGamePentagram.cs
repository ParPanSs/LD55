using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGamePentagram
    {
        [SerializeField] private GameObject _figure;
        public GameObject figure => _figure;
        
        [SerializeField] private GameObject[] _drawings;
        public GameObject[] drawings => _drawings;
        
        public InGamePentagram(GameObject figure, GameObject[] drawings)
        {
            _figure = figure;
            _drawings = drawings;
        }
    }
}
