namespace LudumDare55
{
    public class CatalogueModel
    {
        private string _currentSelectedDemonID;

        public CatalogueModel(string currentSelectedDemonID)
        {
            _currentSelectedDemonID = currentSelectedDemonID;
        }

        public string GetCurrentSelectedDemonID()
        {
            return _currentSelectedDemonID;
        }
    }
}