using UnityEngine;

namespace LudumDare55
{
    public class CatalogueBookmark : MonoBehaviour
    {
        [SerializeField] private string demonID;
        [SerializeField] private CatalogueController _catalogueController;
        private BookmarkEvent bookmarkEvent = new();

        private void Start()
        {
            // _catalogueController = FindAnyObjectByType<CatalogueController>();
            bookmarkEvent.OnBookmarkPressed += _catalogueController.ChangeDemon;
        }
        
        private void OnMouseDown()
        {
            bookmarkEvent.InvokeEvent(demonID);
        }

        private void OnDestroy()
        {
            bookmarkEvent.OnBookmarkPressed -= _catalogueController.ChangeDemon;
        }
    }
}
