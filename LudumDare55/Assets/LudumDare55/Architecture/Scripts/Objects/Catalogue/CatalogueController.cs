﻿namespace LudumDare55
{
    public class CatalogueController
    {
        private CatalogueView _catalogueView;
        private CatalogueModel _catalogueModel;

        public void Construct(CatalogueView catalogueView)
        {
            _catalogueView = catalogueView;
            SetSelectedDemon(1.ToString());
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