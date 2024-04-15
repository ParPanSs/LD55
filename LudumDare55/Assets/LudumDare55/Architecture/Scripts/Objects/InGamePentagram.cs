using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class InGamePentagram
    {
        [SerializeField] private GameObject _figure;
        public GameObject figure => _figure;
        
        [SerializeField] private GameObject _drawing;
        public GameObject drawing => _drawing;
        
        public InGamePentagram(GameObject figure, GameObject drawing)
        {
            _figure = figure;
            _drawing = drawing;
        }
    }
}
