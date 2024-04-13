using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CatalogueController
    {
        [SerializeField] private CatalogueView _catalogueView;
        private CatalogueModel _catalogueModel;
        
        public void ChangeDemon(object sender, string e)
        {
            _catalogueModel = new CatalogueModel(e);
            _catalogueView.DisplayCurrentDemon(e);
        }
    }
}