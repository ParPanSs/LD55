using UnityEngine;

namespace LudumDare55
{
    public class CatalogueBookmark : MonoBehaviour
    {
        [SerializeField] private string demonID;
        [SerializeField] private CatalogueController _catalogueController;
        private BookmarkEvent bookmarkEvent = new();
        
        public void Construct(CatalogueController catalogueController)
        {
            _catalogueController = catalogueController;
            bookmarkEvent.OnBookmarkPressed += _catalogueController.ChangeDemon;
        }
        
        private void OnMouseDown()
        {
            bookmarkEvent.InvokeEvent(demonID);
        }

        private void OnDestroy()
        {
            if (_catalogueController != null) bookmarkEvent.OnBookmarkPressed -= _catalogueController.ChangeDemon;
        }
    }
}
