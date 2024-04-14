using UnityEngine;

namespace LudumDare55
{
    [System.Serializable]
    public class CatalogueController
    {
        [SerializeField] private CatalogueView _catalogueView;
        private CatalogueModel _catalogueModel;

        public void Construct()
        {
            //TODO: Make demon default again
            SetSelectedDemon(0.ToString());
        }
        public void ChangeDemon(object sender, string e)
        {
            SetSelectedDemon(e);
        }

        public string GetSelectedDemon()
        {
            if (_catalogueModel != null)
            {
                return _catalogueModel.GetCurrentSelectedDemonID();
            }

            return string.Empty;
        }

        private void SetSelectedDemon(string currentSelectedDemonID)
        {
            _catalogueModel = new CatalogueModel(currentSelectedDemonID);
            _catalogueView.DisplayCurrentDemon(currentSelectedDemonID);
        }
    }
}